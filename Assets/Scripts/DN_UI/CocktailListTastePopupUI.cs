using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

public class CocktailListTastePopupUI : DaniTechUIBase
{
    [Header("프리팹")]
    [SerializeField] private GameObject Prefeb_Slot;

    [Header("디테일 정보")]
    [SerializeField] private Text Taste_CocktailTaste;
    [SerializeField] private Text Text_CocktailName;

    [Header("슬롯 리스트")]
    [SerializeField] private Transform Transform_TasteSlotRoot;
    [SerializeField] private Transform Transform_NameSlotRoot;

    private Dictionary<string, CocktailSlotUI> _slotList = new Dictionary<string, CocktailSlotUI>();

    private void OnEnable()
    {
        ReadCocktailListAndCreateSlot();
    }



    private void ReadCocktailListAndCreateSlot()
    {
        var dataList = DaniTechGameDataManager.Instance.CocktailDataList;
        List<string> createdTastes = new List<string>();

        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null)
            {
                continue;
            }

            if (createdTastes.Contains(data.TasteType))
            {
                continue;
            }

            createdTastes.Add(data.TasteType);
            CocktailListSlot(data.Id);
        }
    }


    private void CocktailListSlot(string dataId)
    {
        var gObj = Instantiate(Prefeb_Slot, Transform_TasteSlotRoot);
        if (gObj == null)
        {
            Debug.LogWarning("객체의 데이터가 없습니다.");
            return;
        }

        var slotComponent = gObj.GetComponent<CocktailSlotUI>();
        if (slotComponent == null)
        {
            Debug.LogWarning("컴포넌트를 가져오지 못했습니다.");
            return;
        }

        slotComponent.InitSlot(dataId, OnClickChildSlotSelected);
        _slotList.Add(dataId, slotComponent);
    }
    
    private void OnClickChildSlotSelected(string slotDataId)
    {

    }
}
