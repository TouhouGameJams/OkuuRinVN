using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Text m_text;

    public void OnClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Click"));
    }

    public void OnHover()
    {
        m_text = GetComponentInChildren<Text>();
        if(m_text != null)
        {
            m_text.color = Color.red;
        }
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Hover"));

    }

    public void OnExit()
    {
        m_text = GetComponentInChildren<Text>();
        if(m_text != null)
        {
            m_text.color = Color.black;
        }

    }


    public void ExitToClick()
    {
        SaveDataManager saveDataManager = SaveDataManager.Instance;
        saveDataManager.SaveInfo();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void TitleToClick()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}

