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
        transform.SetAsLastSibling();

        if (data == null)
        {
            Debug.LogWarning("팝업에 전달된 칵테일 데이터가 null입니다.");
            return;
        }

        if (Text_CockTailName != null) Text_CockTailName.text = data.Name;
        if (Text_CockTailType != null) Text_CockTailType.text = $"{data.TasteType}, {data.FromType}, {data.MoodType}";

        if (Text_CockTailMakeRecipe != null)
        {
            Text_CockTailMakeRecipe.text = HighlightKeywords(data.MakeRecipe);
        }

        if (Text_CockTailDescription != null)
        {
            Text_CockTailDescription.text = HighlightKeywords(data.Description);
        }
    }
    

    //요것은 색깔바꾸는 함수 이건 Ai에게 부탁했습니다..
    private string HighlightKeywords(string originalText)
    {
        if (string.IsNullOrEmpty(originalText)) return originalText;

        string text = originalText;

        text = text.Replace("브론순 추출액", "<color=#FFCC00>브론순 추출액</color>");
        text = text.Replace("플래너자이드", "<color=#00FF00>플래너자이드</color>");
        text = text.Replace("카모트린", "<color=#A3E7E7>카모트린</color>");
        text = text.Replace("아델하이드", "<color=#FF4545>아델하이드</color>");
        text = text.Replace("델타 가루", "<color=#40A6FF>델타 가루</color>");

        return text;
    }
}
