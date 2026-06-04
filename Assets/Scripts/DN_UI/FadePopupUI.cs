using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePopupUI : DaniTechUIBase
{
    [SerializeField] private Image Image_Panel;

    float time = 0f;
    float F_time = 1f;

    public void Fade(Action onComplete)
    {
        StartCoroutine(FadeFlow(onComplete));
    }

    IEnumerator FadeFlow(Action onComplete)
    {
        Image_Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Image_Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            Image_Panel.color = alpha;
            yield return null;
        }

        onComplete?.Invoke();

        time = 0f;
        yield return new WaitForSeconds(1);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Image_Panel.color = alpha;
            yield return null;
        }
        Image_Panel.gameObject.SetActive(false);
        yield return null;
    }
}
