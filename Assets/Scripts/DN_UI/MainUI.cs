using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private DaniTechUIButton Button_Exit;




    private void OnEnable()
    {
        Button_Exit.BindOnClickButtonEvent(OnClick_Exit);
    }

    private void OnClick_Exit()
    {
        //DaniTechUIManager.Instance.OpenPopupUI();
    }




}
