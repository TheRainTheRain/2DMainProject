using UnityEngine;

public class Opening : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Gamestart;
    [SerializeField] private DaniTechUIButton Button_Quit;

    private void OnEnable()
    {
        Button_Gamestart.BindOnClickButtonEvent(OnClick_GameStart);
        Button_Quit.BindOnClickButtonEvent(OnClick_Quit);
    }

    private void OnClick_GameStart()
    {
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.OpeningUI);
    }

    private void OnClick_Quit()
    {
        DaniTechGameManager.Inst.SaveAndEndGame();
    }
}
