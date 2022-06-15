using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public StateMachine sM;
    // Start is called before the first frame update
    void Start()
    {
        sM.ChangeState(new MenuState { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartToClick()
    {
        SceneManager.LoadScene("Main");
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
