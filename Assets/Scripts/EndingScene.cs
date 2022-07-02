using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlayBGM(soundManager.GetBGM("TitleScreen"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
