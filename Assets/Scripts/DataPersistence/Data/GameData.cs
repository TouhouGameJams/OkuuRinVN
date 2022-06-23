using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string lastSentence;
    public string resolution;
    public int bgmVolume;
    public int sfxVolume;

    public GameData()
    {
        this.resolution = "";
        this.bgmVolume = 0;
        this.sfxVolume = 0;
    }
}
