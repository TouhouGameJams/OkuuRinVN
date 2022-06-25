using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using System.Linq;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public TextMeshProUGUI ScreenResolutionText;

    private float currentBGMVol;
    private float currentSFXVol;

    public Slider BGMSlider;
    public Slider SFXSlider;

    public Toggle fullScreenTog;
    public int isFullScreen;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    // Start is called before the first frame update
    void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGM", 1f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFX", 1f);
        selectedResolution = PlayerPrefs.GetInt("Resolution", 1);
        isFullScreen = PlayerPrefs.GetInt("isFullScreen", 1);
        fullScreenTog.isOn = intToBool(isFullScreen);
        UpdateResLabel();
        ApplyGraphics();
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
        PlayerPrefs.SetFloat("BGM", sliderValue);
        currentBGMVol = Mathf.Log10(sliderValue) * 20f;

        mixer.SetFloat("BGMVolume", currentBGMVol);
    }

    public void SetSFXVolume(float sliderValue)
    {
        PlayerPrefs.SetFloat("SFX", sliderValue);

        currentSFXVol = Mathf.Log10(sliderValue) * 20f;
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20f);
    }

    public void OnClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Click"));
    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        PlayerPrefs.SetInt("Resolution", selectedResolution);
        UpdateResLabel();
        ApplyGraphics();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count- 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        PlayerPrefs.SetInt("Resolution", selectedResolution);
        UpdateResLabel();
        ApplyGraphics();
    }

    public void UpdateResLabel()
    {
        ScreenResolutionText.text = resolutions[selectedResolution].horizontal.ToString() + "x" + resolutions[selectedResolution].vertical.ToString();
    }

    public void FullScreen()
    {
        Screen.fullScreen = fullScreenTog.isOn;
        PlayerPrefs.SetInt("isFullScreen", boolToInt(fullScreenTog.isOn));
    }

    public void ApplyGraphics()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
