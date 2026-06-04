using UnityEngine;

public class OpeningUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Gamestart;
    [SerializeField] private DaniTechUIButton Button_Quit;

    private void OnEnable()
    {
        Button_Gamestart.BindOnClickButtonEvent(OnClick_GameStart);
        Button_Quit.BindOnClickButtonEvent(OnClick_Quit);
        DaniTechSoundManager.Inst.PlayBGM("Sound/Intro_Bgm_1");
    }

    private void OnClick_GameStart()
    {
        DaniTechSoundManager.Inst.StopBGM();
        DaniTechSoundManager.Inst.PlayBGM("Sound/Robby_Bgm_1");
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.OpeningUI);
    }

    private void OnClick_Quit()
    {
        DaniTechGameManager.Inst.SaveAndEndGame();
    }
}
