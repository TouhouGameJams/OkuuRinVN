using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController: MonoBehaviour
{
    private Image buttonImage;

    [SerializeField]
    private Sprite buttonSprite_Neutral;
    [SerializeField]
    private Sprite buttonSprite_Glow;

    private Text m_text;

    private void Start()
    {
        buttonImage = this.GetComponent<Image>();
    }

    public void OnClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Click"));
    }

    public void OnHover()
    {
        m_text = GetComponentInChildren<Text>();
        if (m_text != null)
        {
            m_text.color = Color.red;

            //Change button sprite to one with Glow
            buttonImage.sprite = buttonSprite_Glow;
        }
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Hover"));

    }

    public void OnExit()
    {
        m_text = GetComponentInChildren<Text>();
        if (m_text != null)
        {
            m_text.color = Color.white;
            //Change button sprite to one with Normal upon exit hover
            buttonImage.sprite = buttonSprite_Neutral;
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
}

