using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public CanvasRenderer elementToFade;

    // Start is called before the first frame update
    void Start()
    {
        elementToFade = gameObject.GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("SetBlack")]
    public void SetToBlack()
    {
            gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 255f);
    }

    [YarnCommand("SetWhite")]
    public void SetToWhite()
    {
        gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
    }

    [YarnCommand("FadeOut")]
    public void FadeOut()
    {
        StartCoroutine(FadeRoutine(0f, 1f));
    }

    [YarnCommand("FadeIn")]
    public void FadeIn()
    {
        StartCoroutine(FadeRoutine(1f, 1f));
    }

    [YarnCommand("FadeHalf")]
    public void FadeInHalf()
    {
        StartCoroutine(FadeRoutine(0.5f, 1f));
    }

    IEnumerator FadeRoutine(float endValue, float duration)
    {
        float time = 0;
        float startValue = elementToFade.GetAlpha();
        while (time < duration)
        {
            elementToFade.SetAlpha(Mathf.Lerp(startValue, endValue, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        elementToFade.SetAlpha(endValue);
    }
}
