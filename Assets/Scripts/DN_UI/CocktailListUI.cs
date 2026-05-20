using UnityEngine;
using UnityEngine.UI;

public class CocktailListUI : DaniTechUIBase
{
    [Header("버튼")] 
    [SerializeField] private DaniTechUIButton Button_ChoiceTaste;
    [SerializeField] private DaniTechUIButton Button_ChoiceFrom;
    [SerializeField] private DaniTechUIButton Button_Back;

    private void OnEnable()
    {
        Button_ChoiceTaste.BindOnClickButtonEvent(OnClick_Taste);
        Button_ChoiceFrom.BindOnClickButtonEvent(OnClick_From);
        Button_Back.BindOnClickButtonEvent(OnClick_Back);
    }

    public void OnClick_Taste()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.CocktailListTastePopupUI);
    }

    public void OnClick_From()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.CocktailListFromPopupUI);
    }

    public void OnClick_Back()
    {
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.CocktailListUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.CocktailListTastePopupUI);
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.CocktailListFromPopupUI);
    }
}
