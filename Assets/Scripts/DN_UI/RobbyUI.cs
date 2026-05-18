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
        Debug.Log("나 눌려졌어!!!!!!!!!");
    }

    private void OnClick_Exit()
    {
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.OpeningUI);
        Debug.Log("Exit 하겠습니다.");
    }
}
