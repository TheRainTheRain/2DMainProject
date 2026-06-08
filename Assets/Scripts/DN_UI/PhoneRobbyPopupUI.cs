using UnityEngine;

public class PhoneRobbyPopupUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_AugmentedEye;
    [SerializeField] private DaniTechUIButton Button_MusicCgange;
    [SerializeField] private DaniTechUIButton Button_Save;

    private void OnEnable()
    {
        Button_AugmentedEye.BindOnClickButtonEvent(OnClickAugmenredEye);
        Button_MusicCgange.BindOnClickButtonEvent(OnClickMusicCgange);
        Button_Save.BindOnClickButtonEvent(OnClickSave);
    }

    private void OnClickAugmenredEye()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.AugmenredEyePopupUI);
        Debug.Log("뉴스 팝업이 열립니다.");
    }

    private void OnClickMusicCgange()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.MusicPlayerPopupUI);
        Debug.Log("음악 팝업이 열립니다.");
    }

    private void OnClickSave()
    {
        DaniTechGameManager.Inst.SaveData();
    }
}
