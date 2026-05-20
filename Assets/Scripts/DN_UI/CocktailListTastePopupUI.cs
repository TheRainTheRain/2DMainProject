using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private List<GameObject> _nameSlotObjList = new List<GameObject>();

    private void OnEnable()
    {
        clearAllSlot();
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
        var currentSelectedData = DaniTechGameDataManager.Instance.GetCocktailData(slotDataId);
        if (currentSelectedData == null)
        {
            Debug.LogWarning("칵테일의 데이터를 가져오지 못했습니다.");
            return;
        }

        if(Text_CocktailName == null)
        {
            Debug.LogWarning("인스펙터가 할당되지 않았습니다.");
            return;
        }

        Text_CocktailName.text = currentSelectedData.Name;

        clearNameSlot();

        var dataList = DaniTechGameDataManager.Instance.CocktailDataList;
        string cocktailData = currentSelectedData.TasteType;

        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null)
            {
                continue;
            }
            if(data.TasteType == cocktailData)
            {
                var nameObj = Instantiate(Prefeb_Slot, Transform_NameSlotRoot);
                if (nameObj == null)
                {
                    Debug.LogWarning("타입이 같지 않습니다.");
                    return;
                }

                var nameSlotComponent = nameObj.GetComponent<CocktailSlotUI>();
                if (nameSlotComponent != null)
                {
                    nameSlotComponent.InitSlot(data.Id, null, isTasteDisplay: false);
                }

                _nameSlotObjList.Add(nameObj);
            }
        }
    }

    private void clearNameSlot()
    {
        foreach (var obj  in _nameSlotObjList)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        _nameSlotObjList.Clear();
    }

    private void clearAllSlot()
    {
        foreach (var kvp in _slotList)
        {
            if (kvp.Value != null && kvp.Value.gameObject != null)
            {
                Destroy(kvp.Value.gameObject);
            }
        }
        _slotList.Clear();
    }
}
