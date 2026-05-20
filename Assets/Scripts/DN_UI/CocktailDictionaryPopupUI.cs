using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class CocktailDictionaryPopupUI : DaniTechUIBase
{
    [Header("칵테일 팝업 설명란")]
    [SerializeField] private Text Text_CockTailName;
    [SerializeField] private Text Text_CockTailMakeRecipe;
    [SerializeField] private Text Text_CockTailDescription;
    [SerializeField] private Text Text_CockTailType;

    [Header("닫기 버튼")]
    [SerializeField] private DaniTechUIButton Button_Close;

    private void OnEnable()
    {
        Button_Close.BindOnClickButtonEvent(OnClick_Close);
    }

    private void OnClick_Close()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.CocktailDictionaryPopupUI);
    }

    public void SetCocktailText(CocktailData data)
    {
        if (data == null)
        {
            Debug.LogWarning("팝업에 전달된 칵테일 데이터가 null입니다.");
            return;
        }

        Text_CockTailName.text = data.Name;
        Text_CockTailMakeRecipe.text = data.MakeRecipe;
        Text_CockTailDescription.text = data.Description;
        Text_CockTailType.text = $"{data.TasteType}, {data.FromType}";

    }

}
