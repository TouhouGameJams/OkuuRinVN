using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Thinking : MonoBehaviour
{

    private bool m_isThinking = false;
    [SerializeField] private GameObject m_thinkingObject;
    // Start is called before the first frame update
    void Start()
    {
        Bubble bubble = gameObject.transform.Find("Bubble").GetComponent<Bubble>();
        bubble.IsActive = m_isThinking;
        StartCoroutine(bubble.AppearGradual(0.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    [YarnCommand("StartThinking")]
    public void StartThinking()
    {
        m_isThinking = true;
        Bubble bubble = gameObject.transform.Find("Bubble").GetComponent<Bubble>();
        bubble.IsActive = m_isThinking;
        StartCoroutine(bubble.AppearGradual(1.0f));
    }

    [YarnCommand("FinishThinking")]
    public void FinishThinking()
    {
        m_isThinking = false;
        Bubble bubble = gameObject.transform.Find("Bubble").GetComponent<Bubble>();
        bubble.IsActive = m_isThinking;
        StartCoroutine(bubble.AppearGradual(0.0f));
    }
}
