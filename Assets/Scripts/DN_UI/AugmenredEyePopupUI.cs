using UnityEngine;
using UnityEngine.UI;

public class AugmenredEyePopupUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Back;
    [SerializeField] private DaniTechUIButton Button_Home;
    [SerializeField] private DaniTechUIButton Button_News1;
    [SerializeField] private DaniTechUIButton Button_News2;
    [SerializeField] private DaniTechUIButton Button_News3;

    [SerializeField] private Text Text_News1;
    [SerializeField] private Text Text_News2; 
    [SerializeField] private Text Text_News3;
    [SerializeField] private Text Text_Dialogue;


    private void OnEnable()
    {
        Button_Back.BindOnClickButtonEvent(OnClick_Back);
        Button_Home.BindOnClickButtonEvent(OnClick_Home);
        Button_News1.BindOnClickButtonEvent(OnClick_News1);
        Button_News2.BindOnClickButtonEvent(OnClick_News2);
        Button_News3.BindOnClickButtonEvent(OnClick_News3);
    }

    private void OnClick_Back()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.AugmenredEyePopupUI);
    }

    private void OnClick_Home()
    {   
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.AugmenredEyePopupUI);
    }

    private void OnClick_News1()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.AugmenredEyeTextPopupUI);
        Debug.Log("뉴스 팝업 1이 열립니다.");

        var dataList = DaniTechGameDataManager.Instance.RobbyDialogueDataList;
        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null) continue;
            if (data.Id == "dialogue_talk_1_000")
            {
                Text_News1.text = data.Description;
                break;
            }
        }
    }

    private void OnClick_News2()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.AugmenredEyeTextPopupUI);
        Debug.Log("뉴스 팝업 2가 열립니다.");

        var dataList = DaniTechGameDataManager.Instance.RobbyDialogueDataList;
        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null) continue;
            if (data.Id == "dialogue_talk_1_001")
            {
                Text_News2.text = data.Description;
                break;
            }
        }
    }

    private void OnClick_News3()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.AugmenredEyeTextPopupUI);
        Debug.Log("뉴스 팝업 3이 열립니다.");

        var dataList = DaniTechGameDataManager.Instance.RobbyDialogueDataList;
        foreach (var dataKv in dataList)
        {
            var data = dataKv.Value;
            if (data == null) continue;
            if (data.Id == "dialogue_talk_1_002")
            {
                Text_News3.text = data.Description;
                break;
            }
        }
    }
}
