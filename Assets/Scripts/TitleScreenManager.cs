using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public string targetScene;

    public StateMachine sM;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlayBGM(soundManager.GetBGM("TitleScreen"));
        sM.ChangeState(new MenuState { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartToClick()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.StopBGM();
        LoadingData.sceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScene");
    }

    public void GoToChireiden()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.StopBGM();
        LoadingData.sceneToLoad = "Chireiden";
        SceneManager.LoadScene("LoadingScene");
    }

    public void GoToVillage()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.StopBGM();
        LoadingData.sceneToLoad = "Village";
        SceneManager.LoadScene("LoadingScene");
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
