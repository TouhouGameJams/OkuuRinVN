using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;

public class SoundManager : MonoBehaviour
{
    //===== Begin of Singleton Feature =====//

    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (instance == null)
            {
                Debug.Log("Instance Error in SoundManager.");
            }
        }

        GameObject[] objects = GameObject.FindGameObjectsWithTag("SoundManager");
        if (1 < objects.Length)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

    }

    //===== End of Singleton Feature =====//

    //===== SoundManager Features =====//

    // Volume range is 0.0f between 1.0f
    public AudioMixer mixer;

    public float m_BGM_Volume = 1.0f;
    public float m_SBBGM_Volume = 1.0f;
    public float m_SFX_Volume = 0.5f;
    private const float MIN_VOLUME = 0.0f;
    private const float MAX_VOLUME = 1.0f;
    public AudioInfo current;
    public AudioSource m_BGM_Audio;
    public AudioSource m_SBBGM_Audio;
    public AudioSource m_SFX_Audio;

    [System.Serializable]
    public class AudioInfo
    {
        // Audio Name
        public string name;
        // To play music
        public AudioClip audioClip;
    }

    public List<AudioInfo> m_BGM_List;
    public List<AudioInfo> m_SFX_List;

    void Start()
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(PlayerPrefs.GetFloat("BGM", 1f)) * 20f);
        mixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFX", 1f)) * 20f);
    }

    private void Update()
    {
    }

    public float GetBGMVolume()
    {
        return m_BGM_Volume;
    }

    public void SetBGMVolume(in float bgmVolume)
    {
        m_BGM_Volume = bgmVolume;
        Clamp(ref m_BGM_Volume, MIN_VOLUME, MAX_VOLUME);
    }

    public float GetSBBGMVolume()
    {
        return m_SBBGM_Volume;
    }

    public void SetSBBGMVolume(in float bgmVolume)
    {
        m_BGM_Volume = bgmVolume;
        Clamp(ref m_BGM_Volume, MIN_VOLUME, MAX_VOLUME);
    }

    public float GetSFXVolume()
    {
        return m_SFX_Volume;
    }

    public void SetSFXVolume(in float sfxVolume)
    {
        m_SFX_Volume = sfxVolume;
        Clamp(ref m_SFX_Volume, MIN_VOLUME, MAX_VOLUME);
    }

    private void Clamp(ref float volume, in float min, in float max)
    {
        volume = Mathf.Clamp(volume, min, max);
    }

    [YarnCommand("PlayBGM")]
    public void YarnPlayBGM(string audioName)
    {
        PlayBGM(GetBGM(audioName));
    }

    public AudioInfo GetBGM(in string audioName)
    {
        string findName = audioName;

        return m_BGM_List.Find(audio => findName.Equals(audio.name));
    }

    public void PlayBGM(in AudioInfo audio)
    {
        m_BGM_Audio.clip = audio.audioClip;
        m_BGM_Audio.Play();
        //m_BGM_Audio.PlayOneShot(audio.audioClip, m_BGM_Volume);
    }

    public void PlaySBBGM(in AudioInfo audio)
    {
        m_SBBGM_Audio.clip = audio.audioClip;
        m_SBBGM_Audio.Play();
        //m_SBBGM_Audio.PlayOneShot(audio.audioClip, m_SBBGM_Volume);
    }

    public void PauseBGM()
    {
        m_BGM_Audio.Pause();
    }

    public void ResumeBGM()
    {
        m_BGM_Audio.UnPause();
    }

    [YarnCommand("PlaySFX")]
    public void YarnPlaySFX(string audioName)
    {
        PlaySFX(GetSFX(audioName));
    }

    public AudioInfo GetSFX(in string audioName)
    {
        string findName = audioName;

        return m_SFX_List.Find(audio => findName.Equals(audio.name));
    }

    public void PlaySFX(in AudioInfo audio)
    {
        m_SFX_Audio.PlayOneShot(audio.audioClip, m_SFX_Volume);
    }

    public void PlaySFXString(string audioName)
    {
        PlaySFX(GetSFX(audioName));
    }

    public bool IsPlayingBGM()
    {
        return m_BGM_Audio.isPlaying;
    }

    public bool IsPlayingSBBGM()
    {
        return m_SBBGM_Audio.isPlaying;
    }

    public void StopBGM()
    {
        m_BGM_Audio.Stop();
    }

    public void StopSBBGM()
    {
        m_SBBGM_Audio.Stop();
    }

    public void StopSFX()
    {
        m_SFX_Audio.Stop();
    }

}
