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
        LoadingData.sceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScene");
    }
}
