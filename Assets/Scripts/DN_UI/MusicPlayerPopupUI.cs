using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class MusicPlayerPopupUI : DaniTechUIBase
{
    [SerializeField] private DaniTechUIButton Button_Back;
    [SerializeField] private DaniTechUIButton Button_Music1;
    [SerializeField] private DaniTechUIButton Button_Music2;
    [SerializeField] private DaniTechUIButton Button_Music3;

    private void OnEnable()
    {
        Button_Back.BindOnClickButtonEvent(OnClick_Back);
        Button_Music1.BindOnClickButtonEvent(OnClick_Music1);
        Button_Music2.BindOnClickButtonEvent(OnClick_Music2);
        Button_Music3.BindOnClickButtonEvent(OnClick_Music3);
    }

    private void OnClick_Back()
    {
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.MusicPlayerPopupUI);
        Debug.Log("뮤직 팝업이 닫힙니다.");
    }

    private void OnClick_Music1()
    {
        DaniTechSoundManager.Inst.StopBGM();
        DaniTechSoundManager.Inst.PlayBGM("Sound/Intro_Bgm_1");
    }

    private void OnClick_Music2()
    {
        DaniTechSoundManager.Inst.StopBGM();
        DaniTechSoundManager.Inst.PlayBGM("Sound/Robby_Bgm_1");
    }

    private void OnClick_Music3()
    {
        DaniTechSoundManager.Inst.StopBGM();
        DaniTechSoundManager.Inst.PlayBGM("Sound/Main_Bgm_1");
    }
}