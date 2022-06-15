using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public TextMeshProUGUI ScreenResolutionText;
    private string currentResolution;
    private int currentResolutionIndex = 0;
    private string[] ScreenResArr = new string[] { "1388x768", "1920x1080", "2560x1440" };
    private int[,] ScreenResArr2D = new int[,] { { 1388, 768 }, { 1920, 1080 }, { 2560, 1440 } };
    public bool isFullScreen;

    // Start is called before the first frame update
    void Start()
    {
        isFullScreen = Screen.fullScreen;
        Resolution();
        ScreenResolutionText.text = ScreenResArr[currentResolutionIndex];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CloseOptions()
    {

    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("Main");
    }

    public void SetBGMVolume(float sliderValue)
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20f);
    }

    public void SetSFXVolume(float sliderValue)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20f);
    }

    public void RaiseResolution()
    {
        if(currentResolutionIndex < ScreenResArr.Length)
        {
           currentResolutionIndex++;
           ScreenResolutionText.text = ScreenResArr[currentResolutionIndex];
           Screen.SetResolution(ScreenResArr2D[currentResolutionIndex, 0], ScreenResArr2D[currentResolutionIndex, 1], isFullScreen);
        }
    }

    public void LowerResolution()
    {
        if (currentResolutionIndex > 0)
        {
            currentResolutionIndex--;
            ScreenResolutionText.text = ScreenResArr[currentResolutionIndex];
            Screen.SetResolution(ScreenResArr2D[currentResolutionIndex, 0], ScreenResArr2D[currentResolutionIndex, 1], isFullScreen);
        }
    }

    public void FullScreenToggle()
    {
        if(isFullScreen)
        {
            isFullScreen = false;
            Screen.SetResolution(ScreenResArr2D[currentResolutionIndex, 0], ScreenResArr2D[currentResolutionIndex, 1], isFullScreen);
        }
        else
        {
            isFullScreen = true;
            Screen.SetResolution(ScreenResArr2D[currentResolutionIndex, 0], ScreenResArr2D[currentResolutionIndex, 1], isFullScreen);

        }
    }

    public void Resolution()
    {
        for(int i = 0; i < ScreenResArr.Length; i++)
        {
            if(ScreenResArr[i] == Screen.width.ToString() + "x" + Screen.height.ToString())
            {
                currentResolutionIndex = i;
            }
        }
    }

    public void OnClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Click"));
    }
}
