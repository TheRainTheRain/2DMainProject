using UnityEngine;

public class OpeningUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Gamestart;
    [SerializeField] private DaniTechUIButton Button_Quit;
    [SerializeField] private DaniTechUIButton Button_Setting;

    private void OnEnable()
    {
        Button_Gamestart.BindOnClickButtonEvent(OnClick_GameStart);
        Button_Quit.BindOnClickButtonEvent(OnClick_Quit);
        Button_Setting.BindOnClickButtonEvent(OnClick_Setting);
        DaniTechSoundManager.Inst.PlayBGM("Sound/Intro_Bgm_1");
    }

    private void OnClick_GameStart()
    {
        DaniTechSoundManager.Inst.StopBGM();
        DaniTechUIManager.Instance.OpenFadeUI(OnFadeComplete);
    }

    private void OnFadeComplete()
    {
        DaniTechSoundManager.Inst.PlayBGM("Sound/Robby_Bgm_1");
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.OpeningUI);
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.RobbyUI);
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.RobbyUI);
    }

    private void OnClick_Quit()
    {
        DaniTechGameManager.Inst.SaveAndEndGame();
    }

    private void OnClick_Setting()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.SettingPopupUI);
    }
}
