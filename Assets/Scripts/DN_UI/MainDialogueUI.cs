using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialogueUI : DaniTechUIBase
{
    [SerializeField] private Text Text_MainDialogue;
    [SerializeField] private DaniTechUIButton Button_Next;

    private Queue<string> _dialogueQueue = new Queue<string>();

    private void OnEnable()
    {
        LoadDialogueQueue("dialogue_group_tutorial_1_1");
        ShowNextDialogue();
        Button_Next.BindOnClickButtonEvent(OnClick_Next);
    }

    private void LoadDialogueQueue(string dialogueGroupId)
    {
        _dialogueQueue.Clear();

        var dialogueIdList = DaniTechGameUtil.GetMainDialogueIdList(dialogueGroupId);

        if (dialogueIdList == null)
        {
            Debug.LogWarning("대사 목록을 찾지 못했습니다!");
            return;
        }

        foreach (var dialogueId in dialogueIdList)
        {
            var dialogueData = DaniTechGameDataManager.Instance.GetDialogueData(dialogueId.Trim());
            if (dialogueData == null)
            {
                Debug.LogWarning("대사 데이터가 없습니다.");
                continue;
            }

            _dialogueQueue.Enqueue(dialogueData.Description);
        }
    }

    private void ShowNextDialogue()
    {
        if (_dialogueQueue.Count == 0)
        {
            Debug.Log("모든 대사가 종료되었습니다");
            return;
        }

        Text_MainDialogue.text = _dialogueQueue.Dequeue();
    }

    private bool CheckAndSetDescription()
    {
        bool isNextDescriptionExsit = (_dialogueQueue.Count > 0);
        if (isNextDescriptionExsit)
        {
            string desc = _dialogueQueue.Dequeue();
            Text_MainDialogue.text = desc;
        }

        return isNextDescriptionExsit;
    }

    private void OnClick_Next()
    {
        SetNextPage();
    }

    public void SetNextPage()
    {
        bool isNextDescriptionOpened = CheckAndSetDescription();
    }
}
