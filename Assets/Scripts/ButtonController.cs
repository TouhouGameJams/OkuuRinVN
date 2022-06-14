using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Text m_text;

    public void StartToClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Click"));
    }

    public void OnHover()
    {
        m_text = GetComponentInChildren<Text>();
        m_text.color = Color.red;
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Hover"));

    }

    public void OnExit()
    {
        m_text = GetComponentInChildren<Text>();
        m_text.color = Color.white;

    }

    public void ExitToClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

