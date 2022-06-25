using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private bool m_isActive;
    public bool IsActive { get { return m_isActive; } set { m_isActive = value; } }


    public IEnumerator AppearGradual(float endValue, float duration = 1.0f)
    {
        float time = 0;
        float startValue = Mathf.Abs(1.0f - endValue);
        SpriteRenderer yatagarasuRenderer = GameObject.Find("Yatagarasu").GetComponent<SpriteRenderer>();
        while (time < duration)
        {
            transform.GetComponent<SpriteRenderer>().color = new Color(
                transform.GetComponent<SpriteRenderer>().color.r,
                transform.GetComponent<SpriteRenderer>().color.g,
                transform.GetComponent<SpriteRenderer>().color.b,
                (Mathf.Lerp(startValue, endValue, time / duration))
                );
            yatagarasuRenderer.color = new Color(
                yatagarasuRenderer.color.r,
                yatagarasuRenderer.color.g,
                yatagarasuRenderer.color.b,
                (Mathf.Lerp(startValue, endValue, time / duration))
                );

            time += Time.deltaTime;
            yield return null;
        }
    }

}
