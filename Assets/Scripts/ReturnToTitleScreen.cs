using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleScreen : MonoBehaviour
{
    public string targetScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartToClick()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        SoundManager soundManager = SoundManager.Instance;
        if (soundManager.IsPlayingBGM())
        {
            soundManager.StopBGM();
        }

        if (soundManager.IsPlayingSBBGM())
        {
            soundManager.StopSBBGM();
        }

        LoadingData.sceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScene");
    }
}
