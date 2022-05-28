using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float m_BGM_Volume = 0.5f;
    public float m_SFX_Volume = 0.5f;
    private const float MIN_VOLUME = 0.0f;
    private const float MAX_VOLUME = 1.0f;

    public AudioSource m_AudioSource;

    [System.Serializable]
    public class AudioInfo
    {
        // Audio Name
        public string name;
        // To play music
        public AudioClip AudioClip;
    }

    public List<AudioInfo> m_BGM_List;
    public List<AudioInfo> m_SFX_List;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SetBGMVolume(0.5f);
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

    public AudioInfo GetBGM(in string audioName)
    {
        string findName = audioName;

        return m_BGM_List.Find(audio => findName.Equals(audio.name));
    }

    public void PlayBGM(in AudioInfo audio)
    {
        m_AudioSource.PlayOneShot(audio.AudioClip, m_BGM_Volume);
    }

    public AudioInfo GetSFX(in string audioName)
    {
        string findName = audioName;

        return m_SFX_List.Find(audio => findName.Equals(audio.name));
    }

    public void PlaySFX(in AudioInfo audio)
    {
        m_AudioSource.PlayOneShot(audio.AudioClip, m_SFX_Volume);
    }

}
