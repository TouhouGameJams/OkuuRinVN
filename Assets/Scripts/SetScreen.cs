using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScreen : MonoBehaviour
{
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    private int isFullScreen;
    // Start is called before the first frame update
    void Start()
    {
        selectedResolution = PlayerPrefs.GetInt("Resolution", 1);
        isFullScreen = PlayerPrefs.GetInt("isFullScreen", 1);

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, intToBool(isFullScreen));
    }

    // Update is called once per frame
    void Update()
    {
        
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
