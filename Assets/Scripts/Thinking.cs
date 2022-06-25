using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Thinking : MonoBehaviour
{

    private bool m_isThinking;
    [SerializeField] private GameObject m_thinkingObject;
    // Start is called before the first frame update
    void Start()
    {
        m_isThinking = false;
        SetEnabled();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [YarnCommand("StartThinking")]
    public void StartThinking()
    {
        m_isThinking = true;
        SetEnabled();
    }

    [YarnCommand("FinishThinking")]
    public void FinishThinking()
    {
        m_isThinking = false;
        SetEnabled();
    }

    private void SetEnabled()
    {
        foreach (SpriteRenderer spriteRenderer in m_thinkingObject.GetComponentsInChildren<SpriteRenderer>())
            spriteRenderer.enabled = m_isThinking;
    }
}
