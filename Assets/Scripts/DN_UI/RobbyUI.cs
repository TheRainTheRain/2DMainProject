using UnityEngine;

public class RobbyUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_GoToWork;
    [SerializeField] private DaniTechUIButton Button_Exit;
    [SerializeField] private DaniTechUIButton Button_GoingRobby;

    private void OnEnable()
    {
        Button_GoToWork.BindOnClickButtonEvent(OnClick_GoToWork);
        Button_Exit.BindOnClickButtonEvent(OnClick_Exit);
        Button_GoingRobby.BindOnClickButtonEvent(OnClick_GoingRobby);
    }

    private void OnClick_GoToWork()
    {
        DaniTechSoundManager.Inst.StopBGM();
        DaniTechSoundManager.Inst.PlayBGM("Sound/Main_Bgm_1");
        DaniTechUIManager.Instance.OpenMainDialogueUI(
            "dialogue_group_tutorial_1_1",
            "dialogue_group_tutorial_1_2",
            "dialogue_group_tutorial_1_3"
        );
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.MakeCocktailUI);


        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.RobbyUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.PhoneRobbyPopupUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.AugmenredEyePopupUI);

        Debug.Log("메인 UI로 넘어갑니다.");
    }

    private void OnClick_Exit()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.OpeningExitPopupUI);
        Debug.Log("타이틀로 돌아갑니다.");
    }

    private void OnClick_GoingRobby()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.PhoneRobbyPopupUI);
        Debug.Log("핸드폰 로비창이 열립니다.");
    }
}