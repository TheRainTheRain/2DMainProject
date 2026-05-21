using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public enum SlotTextType
{
    None = 0,
    Taste,
    From,
    Name
}

public class CocktailSlotUI : MonoBehaviour
{
    [SerializeField] private Text Text_SlotName;
    [SerializeField] private DaniTechUIButton Button_SlotClick;

    private Action<string> _onClickSlot;
    private string _slotDataId;

    private void OnEnable()
    {
    }

    private void OnClick_Slot()
    {
        _onClickSlot?.Invoke(_slotDataId);
    }

    private void OnDisable()
    {
        _onClickSlot = null;
    }

    public void InitSlot(string dataId, Action<string> onClickCallback, SlotTextType slotTextType = SlotTextType.Taste)
    {
        var cocktailData = DaniTechGameDataManager.Instance.GetCocktailData(dataId);
        if (cocktailData == null)
        {
            Debug.LogWarning("데이터를 불러올 수 없습니다.");
            return; 
        }

        switch (slotTextType)
        {
            case SlotTextType.Taste:
                Text_SlotName.text = cocktailData.TasteType;
                break;
            case SlotTextType.From:
                Text_SlotName.text = cocktailData.FromType;
                break;
            case SlotTextType.Name:
                Text_SlotName.text = cocktailData.Name;
                break;
        }
      

        _slotDataId = dataId;
        _onClickSlot = onClickCallback;

        if (onClickCallback != null)
        {
            Button_SlotClick.BindOnClickButtonEvent(OnClick_Slot);
        }

    }
}
