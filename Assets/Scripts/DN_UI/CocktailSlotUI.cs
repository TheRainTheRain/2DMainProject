using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class CocktailSlotUI : MonoBehaviour
{
    [SerializeField] private Text Text_SlotName;
    [SerializeField] private DaniTechUIButton Button_SlotClick;

    private event Action<string> _onClickSlot;

    private string _slotDataId;

    private void OnEnable()
    {
        Button_SlotClick.BindOnClickButtonEvent(OnClick_Slot);
    }


    private void OnClick_Slot()
    {
        _onClickSlot.Invoke(_slotDataId);
    }

    private void OnDisable()
    {
        _onClickSlot = null;
    }

    public void IniSlot(string dataId, Action<string> onClickCallback)
    {
        var cocktailData = DaniTechGameDataManager.Instance.GetCocktailData(dataId);
        if (cocktailData == null)
        {
            Debug.LogWarning("데이터를 불러올 수 없습니다.");
            return; 
        }

        Text_SlotName.text = cocktailData.TasteType;


        _slotDataId = dataId;
        _onClickSlot += onClickCallback;
    }
}
