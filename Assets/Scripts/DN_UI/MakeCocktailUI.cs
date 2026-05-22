using UnityEngine;
using UnityEngine.UIElements;

public class MakeCocktailUI : DaniTechUIBase
{
    [Header("칵테일 만드는 버튼")]
    [SerializeField] private DaniTechUIButton Button_Adelhyde;
    [SerializeField] private DaniTechUIButton Button_BronsonExt;
    [SerializeField] private DaniTechUIButton Button_PwdDelta;
    [SerializeField] private DaniTechUIButton Button_Flanergide;
    [SerializeField] private DaniTechUIButton Button_Karmotrine;
    [SerializeField] private DaniTechUIButton Button_Ice;
    [SerializeField] private DaniTechUIButton Button_Age;
    [SerializeField] private Image Image_Shaker;

    [Header("디테일 부분")]
    [SerializeField] private DaniTechUIButton Button_Retry;
    [SerializeField] private DaniTechUIButton Button_Shake;
    [SerializeField] private DaniTechUIButton Button_Submit;

    // 재료 수량 카운트
    private int _countAdelhyde = 0;
    private int _countBronsonExt = 0;
    private int _countPwdDelta = 0;
    private int _countFlanergide = 0;
    private int _countKarmotrine = 0;

    // 얼음과 숙성 체크
    private bool _isIce = false;
    private bool _isAge = false;

    private void OnEnable()
    {
        ButtonBinding();
    }

    private void ButtonBinding()
    {
        Button_Adelhyde.BindOnClickButtonEvent(OnClick_Adelhyde);
        Button_BronsonExt.BindOnClickButtonEvent(OnClick_BronsonExt);
        Button_PwdDelta.BindOnClickButtonEvent(OnClick_PwdDelta);
        Button_Flanergide.BindOnClickButtonEvent(OnClick_Flanergide);
        Button_Karmotrine.BindOnClickButtonEvent(OnClick_Karmotrine);

        Button_Ice.BindOnClickButtonEvent(OnClick_Ice);
        Button_Age.BindOnClickButtonEvent(OnClick_Age);

        Button_Retry.BindOnClickButtonEvent(OnClick_Retry);
        Button_Shake.BindOnClickButtonEvent(OnClick_Shake);
        Button_Submit.BindOnClickButtonEvent(OnClick_Submit);

    }

    private void OnClick_Adelhyde()
    {
        if (_countAdelhyde < 10)
        {
            _countAdelhyde++;
            Debug.Log($"아델하이드를 추가합니다 현재 수량 : {_countAdelhyde}개");
        }
    }

    private void OnClick_BronsonExt()
    {
        if (_countBronsonExt < 10)
        {
            _countBronsonExt++;
            Debug.Log($"브론순 추출액을 추가합니다 현재 수량 : {_countBronsonExt}개");
        }
    }

    private void OnClick_PwdDelta()
    {
        if (_countPwdDelta < 10)
        {
            _countPwdDelta++;
            Debug.Log($"델타가루를 추가합니다 현재 수량 : {_countPwdDelta}개");
        }
    }

    private void OnClick_Flanergide()
    {
        if (_countFlanergide < 10)
        {
            _countFlanergide++;
            Debug.Log($"플래너자이드를 추가합니다 현재 수량 : {_countFlanergide}개");
        }
    }

    private void OnClick_Karmotrine()
    {
        if (_countKarmotrine < 10)
        {
            _countKarmotrine++;
            Debug.Log($"카모트린를 추가합니다 현재 수량 : {_countKarmotrine}개");
        }
    }

    private void OnClick_Shaker()
    {
        
    }

    private void OnClick_Ice()
    {
        _isIce = !_isIce;
        Debug.Log("얼음 상태 변경");
    }

    private void OnClick_Age()
    {
        _isAge = !_isAge;
        Debug.Log("숙성 상태 변경");
    }

    private void OnClick_Retry()
    {
        _countAdelhyde = 0;
        _countBronsonExt = 0;
        _countPwdDelta = 0;
        _countFlanergide = 0;
        _countKarmotrine = 0;
        _isIce = false;
        _isAge = false;
        Debug.Log("쉐이커 깨끗하게 비움!");

        if (Button_Submit != null)
        {
            Button_Submit.gameObject.SetActive(false);
        }
        if (Button_Shake != null)
        {
            Button_Shake.gameObject.SetActive(true);
        }
    }

    private void OnClick_Shake()
    {
        Button_Shake.gameObject.SetActive(false);
        Button_Submit.gameObject.SetActive(true);

    }

    private void OnClick_Submit()
    {
        Button_Submit.gameObject.SetActive(false);
        Button_Shake.gameObject.SetActive(true);

        var dataManager = DaniTechGameDataManager.Instance;
        if (dataManager == null) return;
        if (dataManager.CocktailRecipeDataList == null) return;

        foreach (CocktailRecipeData kv  in dataManager.CocktailDataList)
        {
            CocktailRecipeData recipe = kv;

            if (recipe.Adelhyde == _countAdelhyde &&
                recipe.BronsonExt == _countBronsonExt &&
                recipe.PwdDelta == _countPwdDelta &&
                recipe.Flanergide == _countFlanergide &&
                recipe.Karmotrine == _countKarmotrine &&
                recipe.Ice == _isIce &&
                recipe.Age == _isAge)
            {

            }






        }





    }
}
