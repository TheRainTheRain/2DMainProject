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

    private void CocktailListSlot(string dataId)
    {
        var gObj = Instantiate(Prefeb_Slot);
        if (gObj == null)
        {
            Debug.Log("객체의 데이터가 없습니다.");
            return;
        }

        var slotComponent = gObj.GetComponent<CocktailSlotUI>();
        if (slotComponent == null)
        {
            Debug.Log("컴포넌트를 가져오지 못했습니다.");
            return;
        }











    }




}
