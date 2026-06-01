using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsSlotUI : MonoBehaviour
{
    [SerializeField] private Text Text_MainText;

    private string _slotDataId;

    public void InitSlot(string groupId)
    {
        _slotDataId = groupId;

        var groupData = DaniTechGameDataManager.Instance.GetRobbyDialogueGroupData(groupId);
        if (groupData == null) return;

        var detailId = groupData.DialogueIdList[1];

        var detailData = DaniTechGameDataManager.Instance.GetRobbyDialogueData(detailId);
        if (detailData == null) return;

        Text_MainText.text = detailData.Description;
    }
}
