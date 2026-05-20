using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CocktailSlotUI : MonoBehaviour
{
    public enum TasteType
    {
        Sweet,
        Bitter,
        Sour,
        Bubbly,
        Spicy
    }

    public enum FromType
    {
        Girly,
        Manly,
        Classic,
        Classy,
        Promo
    }


    [SerializeField] private Text Text_SlotName;

    private string _slotDataId;


    public void IniSlot(string dataId)
    {
        var cocktailData = DaniTechGameDataManager.Instance.GetCocktailData(dataId);
        if (cocktailData == null)
        {
            Debug.LogWarning("데이터를 불러올 수 없습니다.");
            return; 
        }

        Text_SlotName.text = cocktailData.TasteType;


        _slotDataId = dataId;

    }
}
