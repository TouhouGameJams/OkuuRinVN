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


    private int[] BGMVolArr = new int[] { 0, 1, 2, 3 };
    private int[] SFXVolArr = new int[] { 0, 1, 2, 3 };

    public bool isFullScreen;

    private float currentBGMVol;
    private float currentSFXVol;
    // Start is called before the first frame update
    void Start()
    {
        isFullScreen = Screen.fullScreen;

        Resolution();

        currentBGMVol = PlayerPrefs.GetInt("BGM");
        currentSFXVol = PlayerPrefs.GetInt("SFX");
        currentResolution = PlayerPrefs.GetString("Resolution");
        ScreenResolutionText.text = ScreenResArr[currentResolutionIndex];

        SetBGMVolume(currentBGMVol);
        SetSFXVolume(currentSFXVol);
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
        currentBGMVol = Mathf.Log10(sliderValue) * 20f;
        mixer.SetFloat("BGMVolume", currentBGMVol);
        PlayerPrefs.SetInt("BGM", (int)currentBGMVol);
    }

    public void SetSFXVolume(float sliderValue)
    {
        currentSFXVol = Mathf.Log10(sliderValue) * 20f;
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20f);
        PlayerPrefs.SetInt("SFX", (int)currentSFXVol);
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
        if (isFullScreen)
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
        for (int i = 0; i < ScreenResArr.Length; i++)
        {
            if(ScreenResArr[i] == Screen.width.ToString() + "x" + Screen.height.ToString())
            {
                currentResolutionIndex = i;
                PlayerPrefs.SetString("Resolution", Screen.width.ToString() + "x" + Screen.height.ToString());
            }
        }
    }

    public void OnClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Click"));
    }
}
