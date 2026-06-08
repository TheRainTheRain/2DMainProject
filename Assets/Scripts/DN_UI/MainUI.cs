using UnityEngine;

public class MainUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Exit;
    [SerializeField] private DaniTechUIButton Button_OpenCocktailList;
    [SerializeField] private DaniTechUIButton Button_Setting;
    [SerializeField] private DaniTechUIButton Button_MusicPlayer;

    private void OnEnable()
    {
        Button_Exit.BindOnClickButtonEvent(OnClick_Exit);
        Button_OpenCocktailList.BindOnClickButtonEvent(OnClick_CocktailList);
        Button_Setting.BindOnClickButtonEvent(OnClick_Setting);
        Button_MusicPlayer.BindOnClickButtonEvent(OnClick_MusicPlayer);
    }

    private void OnClick_Exit()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.OpeningExitPopupUI);
        Debug.Log("타이틀로 돌아갑니다.");
    }

    private void OnClick_CocktailList()
    {
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.CocktailListUI);
        Debug.Log("칵테일 도감이 열립니다.");
    }

    private void OnClick_Setting()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.SettingPopupUI);
    }

    private void OnClick_MusicPlayer()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.MusicPlayerPopupUI);
    }
}
