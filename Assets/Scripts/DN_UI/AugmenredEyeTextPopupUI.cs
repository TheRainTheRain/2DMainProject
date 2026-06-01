using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AugmenredEyeTextPopupUI : DaniTechUIBase
{
    [Header("슬롯")]
    [SerializeField] private GameObject Prefeb_Slot;

    [Header("생성 위치")]
    [SerializeField] private Transform Transform_SlotRoot;

    [Header("디테일 정보")]
    [SerializeField] private Text Text_MainText;
    [SerializeField] private ScrollRect ScrollView;


    [Header("버튼")]
    [SerializeField] private DaniTechUIButton Button_Back;
    [SerializeField] private DaniTechUIButton Button_Home;

    private Dictionary<string, NewsSlotUI> _slotList = new Dictionary<string, NewsSlotUI>();

    private void OnEnable()
    {
        Button_Back.BindOnClickButtonEvent(OnClick_Back);
        Button_Home.BindOnClickButtonEvent(OnClick_Home);
        ScrollView.verticalNormalizedPosition = 1f;
    }

    private void OnDisable()
    {
        foreach (var slot in _slotList.Values)
        {
            if (slot != null)
            {
                Destroy(slot.gameObject);
            }
        }

        _slotList.Clear();
    }

    private void ReadTextListAndCreateSlot()
    {
        var dataList = DaniTechGameDataManager.Instance.RobbyDialogueGroupDataList;
        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null)
            {
                continue;
            }

            CreateNewsSlot(data.Id);
        }
    }

    private void OnClick_Back()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.AugmenredEyeTextPopupUI);
    }

    private void OnClick_Home()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.AugmenredEyeTextPopupUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.AugmenredEyePopupUI);
    }

    private void CreateNewsSlot(string dataId)
    {
        var gObj = Instantiate(Prefeb_Slot, Transform_SlotRoot);
        if (gObj == null) return;

        var slotComponent = gObj.GetComponent<NewsSlotUI>();
        if (slotComponent == null) return;

        slotComponent.InitSlot(dataId);
        _slotList.Add(dataId, slotComponent);
    }

    public void SetupSlot(string groupId)
    {
        foreach (var slot in _slotList.Values)
        {
            if (slot != null) Destroy(slot.gameObject);
        }
        _slotList.Clear();
        CreateNewsSlot(groupId);
    }
}
