using UnityEngine;
using UnityEngine.UI;

public enum TasteType
{
    Sweet,
    Bitter,
    Sour,
    Bubbly,
    Spicy     
}

public class CocktailListTastePopupUI : DaniTechUIBase
{
    [Header("프리팹")]
    [SerializeField] private GameObject Prefeb_Slot;

    [Header("디테일 정보")]
    [SerializeField] private Text Taste_CocktailTaste;
    [SerializeField] private Text Text_CocktailName;

    [Header("슬롯 리스트")]
    [SerializeField] private Transform Transform_TasteSlotRoot;
    [SerializeField] private Transform Transform_NameSlotRoot;







}
