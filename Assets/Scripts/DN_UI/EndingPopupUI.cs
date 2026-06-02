using UnityEngine;

public class EndingPopupUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Btutton_Robby;

    private void OnEnable()
    {
        Btutton_Robby.BindOnClickButtonEvent(OnClick_Robby);
    }

    private void OnClick_Robby()
    {
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.RobbyUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.EndingPopupUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.MainUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.MakeCocktailUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.MainDialogueUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.MainDialogueUI);
    }
}
