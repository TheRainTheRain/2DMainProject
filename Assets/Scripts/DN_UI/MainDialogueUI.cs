using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;
using System.Collections;

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


    public event Action OnDialogueEnd;
    private Action _onDialogueEndCallback;
    private bool _isTyping = false;
    private string _currentTypingSFX = string.Empty;

    private void OnEnable()
    {
        Button_Next.BindOnClickButtonEvent(OnClick_Next);
    }

    private void LoadNextGroup()
    {
        if (_dialogueGroupQueue.Count == 0)
        {
            OnDialogueEnd?.Invoke();
            OnDialogueEnd = null;
            return;
        }

        string groupId = _dialogueGroupQueue.Dequeue();
        LoadDialogueQueue(groupId);
        ShowNextDialogue();
    }

    public void StartDialogue(Action onEndCallback, string[] dialogueGroupIds)
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
        var dialogueData = DaniTechGameDataManager.Instance.GetMainDialogueData(dialogueId);
        if (dialogueData == null)
        {
            Debug.LogWarning($"대사 데이터가 없습니다: {dialogueId}");
            return;
        }

        StartTyping(dialogueData.Description);
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
        if (_isTyping)
        {
            // 타이핑 중이면 즉시 완성
            StopCoroutine(_typingCoroutine);
            Text_MainDialogue.text = originText;
            _isTyping = false;
            return;
        }
        ShowNextDialogue();
    }

    private void OnDisable()
    {
        Button_Next.UnBindOnClickButtonEvent(OnClick_Next);
    }

    //이름과 이름 색상 설정하는 함수
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
                SetTypingSFX(characterData.TypingSFXPath);
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

    private void SetTypingSFX(string typingSFXPath)
    {
        if (string.IsNullOrEmpty(typingSFXPath) == false)
        {
            _currentTypingSFX = typingSFXPath;
        }
        else
        {
            _currentTypingSFX = string.Empty;
        }
    }

    private string originText;
    private Coroutine _typingCoroutine;

    // 텍스트 에셋 사용 부분

    private void StartTyping(string text)
    {
        originText = text;
        Text_MainDialogue.text = "";
        if (_typingCoroutine != null)
            StopCoroutine(_typingCoroutine);
        _isTyping = true;
        _typingCoroutine = StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {
        int typingLength = originText.GetTypingLength();
        for (int index = 0; index <= typingLength; index++)
        {
            Text_MainDialogue.text = originText.Typing(index);
            if (string.IsNullOrEmpty(_currentTypingSFX) == false)
            {
                DaniTechSoundManager.Inst.PlaySFX(_currentTypingSFX);
            }
            yield return new WaitForSeconds(0.03f);
        }
        _isTyping = false;
    }
}
