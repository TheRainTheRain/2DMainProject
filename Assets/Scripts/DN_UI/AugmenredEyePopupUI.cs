using UnityEngine;

public class AugmenredEyePopupUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Back;
    [SerializeField] private DaniTechUIButton Button_Home;
    [SerializeField] private DaniTechUIButton Button_News1;
    [SerializeField] private DaniTechUIButton Button_News2;
    [SerializeField] private DaniTechUIButton Button_News3;


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

    }

    private void OnClick_News2()
    {

    }

    private void OnClick_News3()
    {

    }
}
