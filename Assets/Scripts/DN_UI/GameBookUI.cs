using UnityEngine;
using UnityEngine.UI;

public class GameBookUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_ChoiceTaste;
    [SerializeField] private DaniTechUIButton Button_ChoiceFrom;

    private void OnEnable()
    {
        Button_ChoiceTaste.BindOnClickButtonEvent(OnClick_Taste);
        Button_ChoiceFrom.BindOnClickButtonEvent(OnClick_From);
    }

    public void OnClick_Taste()
    {

    }

    public void OnClick_From()
    {

    }




}
