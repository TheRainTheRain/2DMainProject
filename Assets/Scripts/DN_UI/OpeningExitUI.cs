using UnityEngine;

public class OpeningExitUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_ExitYes;
    [SerializeField] private DaniTechUIButton Button_ExitNo;

    private void OnEnable()
    {
        Button_ExitYes.BindOnClickButtonEvent(OnClick_ExitYes);
        Button_ExitNo.BindOnClickButtonEvent(OnClick_ExitNo);
    }

    private void OnClick_ExitYes()
    {
        DaniTechUIManager.Instance.OpenOpeningUI();
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.RobbyUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.OpeningExitPopupUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.MakeCocktailUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.MainDialogueUI);
        Debug.Log("타이틀 화면이 열립니다!");
    }

    private void OnClick_ExitNo()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.OpeningExitPopupUI);
        Debug.Log("나가기 창이 닫힙니다!");
    }

}
