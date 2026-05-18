using UnityEngine;

public class MainUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Exit;




    private void OnEnable()
    {
        Button_Exit.BindOnClickButtonEvent(OnClick_Exit);
    }

    private void OnClick_Exit()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.OpeningExitPopupUI);
        Debug.Log("타이틀로 돌아갑니다.");
    }
}
