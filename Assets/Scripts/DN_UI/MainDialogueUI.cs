using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialogueUI : DaniTechUIBase
{
    [SerializeField] private Text Text_MainDialogue;
    [SerializeField] private DaniTechUIButton Button_Next;

    private Queue<string> _dialogueGroupQueue = new Queue<string>();
    private Queue<string> _dialogueQueue = new Queue<string>();

    private void OnEnable()
    {
        Button_Next.BindOnClickButtonEvent(OnClick_Next);
    }

    private string _nextDialogueGroupId;

    public void StartDialogue(params string[] dialogueGroupIds)
    {
        _dialogueGroupQueue.Clear();
        foreach (var groupId in dialogueGroupIds)
        {
            _dialogueGroupQueue.Enqueue(groupId);
        }
        LoadNextGroup();
    }

    private void LoadNextGroup()
    {
        if (_dialogueGroupQueue.Count == 0)
        {
            return;
        }

        string groupId = _dialogueGroupQueue.Dequeue();
        LoadDialogueQueue(groupId);
        ShowNextDialogue();
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
    }

    private void OnClick_Next()
    {
        ShowNextDialogue();
    }
}
