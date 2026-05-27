using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialogueUI : DaniTechUIBase
{
    [SerializeField] private GameObject Layout_CharacterName;
    [SerializeField] private Text Text_MainDialogue;
    [SerializeField] private Text Text_Name;
    [SerializeField] private DaniTechUIButton Button_Next;
    [SerializeField] private RawImage RawImage_Character;

    private Queue<string> _dialogueGroupQueue = new Queue<string>();
    private Queue<string> _dialogueQueue = new Queue<string>();
    private string _currentDialogueGroupId = string.Empty;

    //요건 AI한테..
    private System.Action _onDialogueEndCallback;

    private void OnEnable()
    {
        Button_Next.BindOnClickButtonEvent(OnClick_Next);
    }

    private void LoadNextGroup()
    {
        if (_dialogueGroupQueue.Count == 0)
        {
            _onDialogueEndCallback?.Invoke();
            _onDialogueEndCallback = null;
            return;
        }

        string groupId = _dialogueGroupQueue.Dequeue();
        LoadDialogueQueue(groupId);
        ShowNextDialogue();
    }

    public void StartDialogue(System.Action onEndCallback = null, params string[] dialogueGroupIds)
    {
        _onDialogueEndCallback = onEndCallback;
        _dialogueGroupQueue.Clear();
        foreach (var groupId in dialogueGroupIds)
        {
            _dialogueGroupQueue.Enqueue(groupId);
        }
        LoadNextGroup();
    }

    private void LoadDialogueQueue(string dialogueGroupId)
    {
        _dialogueQueue.Clear();

        var dialogueIdList = DaniTechGameUtil.GetMainDialogueIdList(dialogueGroupId);

        Debug.Log($"ID 개수: {dialogueIdList?.Count}");

        if (dialogueIdList == null)
        {
            Debug.LogWarning("대사 목록을 찾지 못했습니다!");
            return;
        }

        foreach (var dialogueId in dialogueIdList)
        {
            _dialogueQueue.Enqueue(dialogueId.Trim());
        }
    }

    private void ShowNextDialogue()
    {
        if (_dialogueQueue.Count == 0)
        {
            LoadNextGroup();
            return;
        }

        string dialogueId = _dialogueQueue.Dequeue();
        var dialogueData = DaniTechGameDataManager.Instance.GetDialogueData(dialogueId);
        if (dialogueData == null)
        {
            Debug.LogWarning($"대사 데이터가 없습니다: {dialogueId}");
            return;
        }

        Text_MainDialogue.text = dialogueData.Description;
        SetCharacterName(dialogueData.CharacterDataId);

        if (string.IsNullOrEmpty(dialogueData.TexturePath) == false)
        {
            Debug.Log($"텍스처 경로: [{dialogueData.TexturePath}]");
            RawImage_Character.gameObject.SetActive(true);
            DaniTechGameUtil.LoadAndSetTexture(RawImage_Character, dialogueData.TexturePath).Forget();
        }
        else
        {
            RawImage_Character.gameObject.SetActive(false);
        }
    }

    private void OnClick_Next()
    {
        ShowNextDialogue();
    }

    private void OnDisable()
    {
        Button_Next.UnBindOnClickButtonEvent(OnClick_Next);
    }

    private void SetCharacterName(string characterDataId)
    {
        bool isActive = (string.IsNullOrEmpty(characterDataId) == false);
        Layout_CharacterName.SetActive(isActive);

        if (isActive)
        {
            var characterData = DaniTechGameDataManager.Instance.GetCharacterData(characterDataId);
            if (characterData != null)
            {
                string displayName = characterData.Name;
                if (displayName.Length <= 2)
                {
                    // 여백을 없애주는 코드입니다.
                    Text_Name.text = $"{displayName}:\t";
                }
                else
                {
                    Text_Name.text = $"{displayName}";
                }

                if (string.IsNullOrEmpty(characterData.NameColor) == false)
                {
                    if (ColorUtility.TryParseHtmlString(characterData.NameColor, out Color parsedColor))
                    {
                        Text_Name.color = parsedColor;
                    }
                }
                else
                {
                    Text_Name.color = Color.white;
                }
            }
        }
    }
}
