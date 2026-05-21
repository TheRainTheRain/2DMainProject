using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocktailListFromPopupUI : DaniTechUIBase
{
    [Header("프리팹")]
    [SerializeField] private GameObject Prefeb_Slot;

    [Header("디테일 정보")]
    [SerializeField] private Text txt_SearchCriteria;
    [SerializeField] private Text txt_SelectedDetailName;

    [Header("슬롯 리스트 루트")]
    [SerializeField] private Transform Transform_FromSlotRoot;
    [SerializeField] private Transform Transform_NameSlotRoot;

    private Dictionary<string, CocktailSlotUI> _slotList = new Dictionary<string, CocktailSlotUI>();
    private List<GameObject> _nameSlotObjList = new List<GameObject>();

    private void OnEnable()
    {
        ClearUI();
        ReadCocktailListAndCreateSlot();
    }

    private void ReadCocktailListAndCreateSlot()
    {
        var dataList = DaniTechGameDataManager.Instance.CocktailDataList;
        List<string> createdFroms = new List<string>();

        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null) continue;

            if (createdFroms.Contains(data.FromType))
            {
                continue;
            }

            createdFroms.Add(data.FromType);
            CocktailListSlot(data.Id);
        }
    }

    private void CocktailListSlot(string dataId)
    {
        var gObj = Instantiate(Prefeb_Slot, Transform_FromSlotRoot);
        if (gObj == null) return;

        var slotComponent = gObj.GetComponent<CocktailSlotUI>();
        if (slotComponent == null) return;

        slotComponent.InitSlot(dataId, OnClickChildSlotSelected, SlotTextType.From);
        _slotList.Add(dataId, slotComponent);
    }

    private void OnClickChildSlotSelected(string slotDataId)
    {
        var currentSelectedData = DaniTechGameDataManager.Instance.GetCocktailData(slotDataId);
        if (currentSelectedData == null) return;

        if (txt_SelectedDetailName != null)
        {
            txt_SelectedDetailName.text = currentSelectedData.Name;
        }

        ClearNameSlot();

        var dataList = DaniTechGameDataManager.Instance.CocktailDataList;
        string clickedFrom = currentSelectedData.FromType;

        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null) continue;

            if (data.FromType == clickedFrom)
            {
                var nameObj = Instantiate(Prefeb_Slot, Transform_NameSlotRoot);
                if (nameObj == null) continue;

                var nameSlotComponent = nameObj.GetComponent<CocktailSlotUI>();
                if (nameSlotComponent != null)
                {
                    nameSlotComponent.InitSlot(data.Id, OnClickCocktailNameSelected, SlotTextType.Name);
                }

                _nameSlotObjList.Add(nameObj);
            }
        }
    }

    private void OnClickCocktailNameSelected(string cocktailId)
    {
        var cocktailData = DaniTechGameDataManager.Instance.GetCocktailData(cocktailId);
        if (cocktailData == null) return;

        var detailPopup = DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.CocktailDictionaryPopupUI) as CocktailDictionaryPopupUI;
        if (detailPopup != null)
        {
            detailPopup.SetCocktailText(cocktailData);
        }
    }

    private void ClearNameSlot()
    {
        foreach (var obj in _nameSlotObjList)
        {
            if (obj != null) Destroy(obj);
        }
        _nameSlotObjList.Clear();
    }

    private void ClearAllSlot()
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

    private void ClearUI()
    {
        if (txt_SelectedDetailName != null) txt_SelectedDetailName.text = string.Empty;
        ClearNameSlot();
        ClearAllSlot();
    }
}