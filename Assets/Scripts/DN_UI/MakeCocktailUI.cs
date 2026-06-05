using Cysharp.Threading.Tasks;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Image Image_Result;

    [Header("디테일 부분")]
    [SerializeField] private DaniTechUIButton Button_Retry;
    [SerializeField] private DaniTechUIButton Button_Shake;
    [SerializeField] private DaniTechUIButton Button_Submit;
    [SerializeField] private DaniTechUIButton Button_Stop;

    [Header("쉐이커 게이지 슬롯")]
    [SerializeField] private Transform Transform_SlotGroupBottom;
    [SerializeField] private Transform Transform_SlotGroupTop;

    [Header("재료 슬롯")]
    [SerializeField] private Transform Transform_SlotAdelhyde;
    [SerializeField] private Transform Transform_SlotBronsonExt;
    [SerializeField] private Transform Transform_SlotPwdDelta;
    [SerializeField] private Transform Transform_SlotFlanergide;
    [SerializeField] private Transform Transform_SlotKarmotrine;

    [Header("슬롯 스프라이트")]
    [SerializeField] private Sprite Sprite_SlotEmpty;
    [SerializeField] private Sprite Sprite_SlotAdlehyde;
    [SerializeField] private Sprite Sprite_BronsonExt;
    [SerializeField] private Sprite Sprite_PwdDelta;
    [SerializeField] private Sprite Sprite_Flanergide;
    [SerializeField] private Sprite Sprite_Karmotrine;

    [Header("얼음/숙성 스프라이트")]
    [SerializeField] private Sprite Sprite_Ice_On;
    [SerializeField] private Sprite Sprite_Ice_Off;
    [SerializeField] private Sprite Sprite_Age_On;
    [SerializeField] private Sprite Sprite_Age_Off;

    [Header("쉐이커 관련")]
    [SerializeField] private ShakerAnim ShakerAnim;
    private Sprite _defaultShakerSprite;

    private Image[] _slot_GroupBottom;
    private Image[] _slot_GroupTop;
    private Image[] _slot_Adelhyde;
    private Image[] _slot_BronsonExt;
    private Image[] _slot_PwdDelta;
    private Image[] _slot_Flanergide;
    private Image[] _slot_Karmotrine;

    // 재료 수량 카운트
    private int _countAdelhyde = 0;
    private int _countBronsonExt = 0;
    private int _countPwdDelta = 0;
    private int _countFlanergide = 0;
    private int _countKarmotrine = 0;

    // 얼음과 숙성 체크
    private bool _isIce = false;
    private bool _isAge = false;
    private bool _isShaking = false;

    private CocktailRecipeData _currentMatchedRecipe;

    private void OnEnable()
    {
        _defaultShakerSprite = Image_Shaker.sprite;
        Image_Result.gameObject.SetActive(false);
        InitSlots();
        ButtonBinding();
        RefreshSlots();
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
        Button_Stop.BindOnClickButtonEvent(OnClick_Stop);
        Button_Submit.BindOnClickButtonEvent(OnClick_Submit);
    }

    private void OnClick_Adelhyde()
    {
        if (_countAdelhyde < 10)
        {
            _countAdelhyde++;
            RefreshSlots();
            Debug.Log($"아델하이드를 추가합니다 현재 수량 : {_countAdelhyde}개");
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Alcohol_In_Shaker");
        }
    }

    private void OnClick_BronsonExt()
    {
        if (_countBronsonExt < 10)
        {
            _countBronsonExt++;
            RefreshSlots();
            Debug.Log($"브론순 추출액을 추가합니다 현재 수량 : {_countBronsonExt}개");
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Alcohol_In_Shaker");
        }
    }

    private void OnClick_PwdDelta()
    {
        if (_countPwdDelta < 10)
        {
            _countPwdDelta++;
            RefreshSlots();
            Debug.Log($"델타가루를 추가합니다 현재 수량 : {_countPwdDelta}개");
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Alcohol_In_Shaker");
        }
    }

    private void OnClick_Flanergide()
    {
        if (_countFlanergide < 10)
        {
            _countFlanergide++;
            RefreshSlots();
            Debug.Log($"플래너자이드를 추가합니다 현재 수량 : {_countFlanergide}개");
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Alcohol_In_Shaker");
        }
    }

    private void OnClick_Karmotrine()
    {
        if (_countKarmotrine < 10)
        {
            _countKarmotrine++;
            RefreshSlots();
            Debug.Log($"카모트린를 추가합니다 현재 수량 : {_countKarmotrine}개");
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Alcohol_In_Shaker");
        }
    }

    private void OnClick_Ice()
    {
        _isIce = !_isIce;
        Button_Ice.ChangeButtonSprite(_isIce ? Sprite_Ice_On : Sprite_Ice_Off);

        if (_isIce)
        {
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Ice_In_Shaker");
        }
        Debug.Log("얼음 상태 변경");
    }

    private void OnClick_Age()
    {
        _isAge = !_isAge;
        Button_Age.ChangeButtonSprite(_isAge ? Sprite_Age_On : Sprite_Age_Off);
        if (_isAge)
        {
            DaniTechSoundManager.Inst.PlaySFX("Sound/SFX_Age");
        }
        Debug.Log("숙성 상태 변경");
    }

    // 요 부분은 AI가 많이 도와줬습니다,,, ======================= 기능 관련 메서드들 입니다 =====================

    private void OnClick_Retry()
    {
        _isShaking = false;
        Image_Result.gameObject.SetActive(false);
        ShowShaker();
        ShakerAnim.SteShakerAnimState(ShakerAnimState.Idle);
        ShakerAnim.transform.rotation = Quaternion.identity;

        _currentMatchedRecipe = null;
        _countAdelhyde = 0;
        _countBronsonExt = 0;
        _countPwdDelta = 0;
        _countFlanergide = 0;
        _countKarmotrine = 0;
        _isIce = false;
        _isAge = false;
        Button_Ice.ChangeButtonSprite(Sprite_Ice_Off);
        Button_Age.ChangeButtonSprite(Sprite_Age_Off);
        RefreshSlots();

        Button_Shake?.gameObject.SetActive(true);
        Button_Shake?.UnBindOnClickButtonEvent(OnClick_Shake);
        Button_Shake?.BindOnClickButtonEvent(OnClick_Shake);
        Button_Stop?.gameObject.SetActive(false);
        Button_Submit?.gameObject.SetActive(false);

        Button_Submit?.UnBindOnClickButtonEvent(OnClick_Submit);
        Button_Submit?.BindOnClickButtonEvent(OnClick_Submit);
        Debug.Log("쉐이커 깨끗하게 비움!");
    }

    private void OnClick_Shake()
    {
        Debug.Log("OnClick_Shake 호출됨!");

        _isShaking = true;

        ShakerAnim.SteShakerAnimState(ShakerAnimState.Shake);
        Button_Shake.gameObject.SetActive(false);
        Button_Stop.gameObject.SetActive(true);
        Button_Stop.UnBindOnClickButtonEvent(OnClick_Stop);
        Button_Stop.BindOnClickButtonEvent(OnClick_Stop);
        Button_Submit.gameObject.SetActive(false);
    }

    private void OnClick_Stop()
    {
        Debug.Log("OnClick_Stop 호출됨!");

        _isShaking = false;

        ShakerAnim.SteShakerAnimState(ShakerAnimState.Idle);
        Button_Shake.gameObject.SetActive(false);
        Button_Stop.gameObject.SetActive(false);

        var dataManager = DaniTechGameDataManager.Instance;
        if (dataManager == null || dataManager.CocktailRecipeDataList == null) return;

        _currentMatchedRecipe = FindMatchedRecipe(dataManager);

        if (_currentMatchedRecipe != null)
        {
            OnRecipeMatchSuccess();
        }
        else
        {
            OnRecipeMatchFail(dataManager);
        }
    }


    // 손님 관련
    private GuestData _currentGuest;
    private string[] _guestOrder = { "guest_donoban_01", "guest_sei_01" };
    private int _currentGuestIndex = 0;

    private void LoadNextGuest()
    {
        // Length -> 배열이 몇개인지 가져오는것
        if (_currentGuestIndex >= _guestOrder.Length)
        {
            DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.EndingPopupUI);
            Debug.Log("모든 손님 완료");
            return;
        }

        // 인덱스 배열로 손님 Id 가져오기
        string guestId = _guestOrder[_currentGuestIndex];

        // 데이터 매니제에서 손님 데이터 가져오기
        _currentGuest = DaniTechGameDataManager.Instance.GetGuestData(guestId);

        _currentGuestIndex++;

        if (_currentGuest == null)
        {
            Debug.LogWarning($"손님 데이터가 없습니다 {guestId}");
            return;
        }

        var dialogueUI = DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.MainDialogueUI) as MainDialogueUI;
        if (dialogueUI != null)
        {
            dialogueUI.StartDialogue(null, new string[] { _currentGuest.DialogueGroupId });
        }

    }

    private CocktailRecipeData FindMatchedRecipe(DaniTechGameDataManager dataManager)
    {
        foreach (var kv in dataManager.CocktailRecipeDataList)
        {
            var recipe = kv.Value;

            bool isKarmotrineMatch = recipe.Optional
            ? true
            : recipe.Karmotrine == _countKarmotrine;

            if (recipe.Adelhyde == _countAdelhyde &&
                recipe.BronsonExt == _countBronsonExt &&
                recipe.PwdDelta == _countPwdDelta &&
                recipe.Flanergide == _countFlanergide &&
                isKarmotrineMatch &&
                recipe.Ice == _isIce &&
                recipe.Age == _isAge)
            {
                return recipe;
            }
        }
        return null;
    }

    private void OnRecipeMatchSuccess()
    {
        HideShaker();
        Image_Result.gameObject.SetActive(true);
        Button_Submit?.gameObject.SetActive(true);
        Button_Submit?.UnBindOnClickButtonEvent(OnClick_Submit);
        Button_Submit?.BindOnClickButtonEvent(OnClick_Submit);
        DaniTechGameUtil.LoadAndSetSpriteImage(Image_Result, _currentMatchedRecipe.IconPath).Forget();
    }

    private void OnRecipeMatchFail(DaniTechGameDataManager dataManager)
    {
        HideShaker();
        Image_Result.gameObject.SetActive(true);
        Image_Shaker.gameObject.SetActive(false);
        Button_Submit?.gameObject.SetActive(false);
        const string failId = "Cocktail_Fail_1";
        var failData = dataManager.GetCocktailData(failId);

        if (failData != null && !string.IsNullOrEmpty(failData.IconPath))
        {
            Image_Result.gameObject.SetActive(true);
            DaniTechGameUtil.LoadAndSetSpriteImage(Image_Result, failData.IconPath).Forget();
        }
    }

    private void OnClick_Submit()
    {
        Debug.Log("OnClick_Submit 호출됨!");
        Debug.Log($"_currentMatchedRecipe null 여부: {_currentMatchedRecipe == null}");

        if (_currentMatchedRecipe == null)
        {
            Debug.LogWarning("매칭된 레시피가 없습니다.");
            return;
        }

        string recipeId = _currentMatchedRecipe.Id;
        Debug.Log($"recipeId: {recipeId}");

        bool isSuccess = false;
        if (_currentGuest == null)
        {
            isSuccess = (recipeId == "Cocktail_SugarRush_2" || recipeId == "Cocktail_PianoMan_2");
        }
        else
        {
            isSuccess = (_currentGuest.OrderCocktailId == recipeId);
        }

        if (isSuccess) OnSubmitSuccess();
        else OnSubmitFail();
    }

    private void OnSubmitSuccess()
    {
        OnClick_Retry();
        var dialogueUI = DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.MainDialogueUI) as MainDialogueUI;
        if (dialogueUI == null) return;

        if (_currentGuest == null)
        {
            dialogueUI.OnDialogueEnd += OnGuestSuccessDialogueEnd;
            dialogueUI.StartDialogue(null, new string[] { "dialogue_group_tutorial_1_3_success" });
        }
        else
        {
            dialogueUI.OnDialogueEnd += OnGuestSuccessDialogueEnd;
            dialogueUI.StartDialogue(null, new string[] { _currentGuest.DialogueGroupId + "_success" });
        }

    }

    private void OnSubmitFail()
    {
        OnClick_Retry();
        var dialogueUI = DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.MainDialogueUI) as MainDialogueUI;
        if (dialogueUI == null) return;

        if (_currentGuest == null)
        {
            dialogueUI.OnDialogueEnd += OnGuestFailDialogueEnd;
            dialogueUI.StartDialogue(null, new string[] { "dialogue_group_tutorial_1_3_fail" });
        }
        else
        {
            dialogueUI.OnDialogueEnd += OnGuestFailDialogueEnd;
            dialogueUI.StartDialogue(null, new string[] {_currentGuest.DialogueGroupId + "_fail" });
        }
    }

    private void OnGuestSuccessDialogueEnd()
    {
        LoadNextGuest();
    }

    private void OnGuestFailDialogueEnd()
    {

    }

    private void UpdateSlot(Image[] slot, int count, Sprite sprite)
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (i < count)
            {
                slot[i].sprite = sprite;
            }
            else
            {
                slot[i].sprite = Sprite_SlotEmpty;
            }
        }
    }

    // ref 는 원본을 바꿔버린다.
    private void AddCount(ref int count)
    {
        if (count < 10)
        {
            count++;
            RefreshSlots();
        }
    }

    private void RefreshSlots()
    {
        UpdateSlot(_slot_Adelhyde, _countAdelhyde, Sprite_SlotAdlehyde);
        UpdateSlot(_slot_BronsonExt, _countBronsonExt, Sprite_BronsonExt);
        UpdateSlot(_slot_PwdDelta, _countPwdDelta, Sprite_PwdDelta);
        UpdateSlot(_slot_Flanergide, _countFlanergide, Sprite_Flanergide);
        UpdateSlot(_slot_Karmotrine, _countKarmotrine, Sprite_Karmotrine);
        UpdateGaugeSlots();
    }

    private void InitSlots()
    {
        _slot_Adelhyde = Transform_SlotAdelhyde.GetComponentsInChildren<Image>();
        _slot_BronsonExt = Transform_SlotBronsonExt.GetComponentsInChildren<Image>();
        _slot_PwdDelta = Transform_SlotPwdDelta.GetComponentsInChildren<Image>();
        _slot_Flanergide = Transform_SlotFlanergide.GetComponentsInChildren<Image>();
        _slot_Karmotrine = Transform_SlotKarmotrine.GetComponentsInChildren<Image>();
        _slot_GroupBottom = Transform_SlotGroupBottom.GetComponentsInChildren<Image>();
        _slot_GroupTop = Transform_SlotGroupTop.GetComponentsInChildren<Image>();
    }

    private void UpdateGaugeSlots()
    {
        int total = _countAdelhyde + _countBronsonExt + _countPwdDelta + _countFlanergide + _countKarmotrine;

        for (int i = 0; i < _slot_GroupBottom.Length; i++)
        {
            _slot_GroupBottom[i].gameObject.SetActive(i < total);
        }

        for (int i = 0; i < _slot_GroupTop.Length; i++)
        {
            _slot_GroupTop[i].gameObject.SetActive(i < (total - 10));
        }
    }

    private void OnFailDialogueEnd()
    {
        DaniTechUIManager.Instance.OpenContentUI(DaniTechUIType.MakeCocktailUI);
    }

    private void HideShaker()
    {
        var color = Image_Shaker.color;
        color.a = 0f;
        Image_Shaker.color = color;
        ShakerAnim.SteShakerAnimState(ShakerAnimState.Idle);
    }

    private void ShowShaker()
    {
        Image_Shaker.gameObject.SetActive(true);
        var color = Image_Shaker.color;
        color.a = 1f;
        Image_Shaker.color = color;
    }
}
