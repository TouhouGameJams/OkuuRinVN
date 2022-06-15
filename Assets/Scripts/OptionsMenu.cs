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

    // Start is called before the first frame update
    void Start()
    {

        currentBGMVol = PlayerPrefs.GetInt("BGM");
        currentSFXVol = PlayerPrefs.GetInt("SFX");
        currentResolution = PlayerPrefs.GetString("Resolution");

        isFullScreen = Screen.fullScreen;

        Resolution();
        ScreenResolutionText.text = ScreenResArr[currentResolutionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        BGMVolumeText.text = currentBGMVol.ToString();
        SFXVolumeText.text = currentSFXVol.ToString();
        Debug.Log(currentResolutionIndex);
        Debug.Log(ScreenResArr2D[currentResolutionIndex, 0]);

    }

    public void CloseOptions()
    {

    }

    public void ReturnToTitleScreen()
    {

        //SceneManager.LoadScene(0);
    }

    public void RaiseBGMVolume()
    {
        if (currentBGMVol < 5)
        {
            bgmMixer.GetFloat("BGMVolume", out currentBGMVolFloat);
            bgmMixer.SetFloat("BGMVolume", currentBGMVolFloat + 20f);
            currentBGMVol++;
        }
    }

    public void LowerBGMVolume()
    {
        if (currentBGMVol > 0)
        {
            bgmMixer.GetFloat("BGMVolume", out currentBGMVolFloat);
            bgmMixer.SetFloat("BGMVolume", currentBGMVolFloat - 20f);
            currentBGMVol--;
        }

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

        if (currentResolutionIndex <= ScreenResArr.Length)

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

            if (ScreenResArr[i] == baseResolution)

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
