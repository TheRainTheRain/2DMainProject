using UnityEngine;
using UnityEngine.UI;

public class SettingPopupUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Back;
    [SerializeField] private Slider Slider_BGM;
    [SerializeField] private Slider Slider_SFX;


    private void OnEnable()
    {
        Button_Back.BindOnClickButtonEvent(OnClick_Back);

        // 버튼 바인트랑 같은 개념 이벤트를 여는 것
        Slider_BGM.onValueChanged.AddListener(OnChange_BGM);
        Slider_SFX.onValueChanged.AddListener(OnChange_SFX);

        InitSliderVolume();
    }

    private void OnClick_Back()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.SettingPopupUI);
    }

    private void OnChange_BGM(float value)
    {
        DaniTechSoundManager.Inst.BGMVolume = value;
    }

    private void OnChange_SFX(float value)
    {
        DaniTechSoundManager.Inst.SFXVolume = value;
    }

    private void InitSliderVolume()
    {
        Slider_BGM.value = DaniTechSoundManager.Inst.BGMVolume;
        Slider_SFX.value = DaniTechSoundManager.Inst.SFXVolume;
    }
}
