using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

public class NewsSlotUI : MonoBehaviour
{
    [SerializeField] private Text Text_MainText;

    private string _slotDataId;

    public void InitSlot(string dataId)
    {
        _slotDataId = dataId;

        var dataList = DaniTechGameDataManager.Instance.RobbyDialogueDataList;
        RobbyDialogueData targetData = null;

        foreach (var dataKv in  dataList)
        {
            var textData = dataKv.Value;
            if (textData == null) continue;
        }

        Text_MainText.text = targetData.Description;
    }



}
