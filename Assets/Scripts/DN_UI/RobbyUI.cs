using UnityEngine;

public class RobbyUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_GoToWork;
    [SerializeField] private DaniTechUIButton Button_Exit;

    private void OnEnable()
    {
        Button_GoToWork.BindOnClickButtonEvent(OnClick_GoToWork);
        Button_Exit.BindOnClickButtonEvent(OnClick_Exit);
    }

    private void OnClick_GoToWork()
    {
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.RobbyUI);
        DaniTechUIManager.Instance.OpenMainDialogueUI(
            null,
            "dialogue_group_tutorial_1_1",
            "dialogue_group_tutorial_1_2",
            "dialogue_group_tutorial_1_3"
        );
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.MakeCocktailUI);
        Debug.Log("메인 UI로 넘어갑니다.");
    }

    private void OnClick_Exit()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.OpeningExitPopupUI);
        Debug.Log("타이틀로 돌아갑니다.");
    }
}