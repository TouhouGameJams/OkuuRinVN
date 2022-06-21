using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ImageCG : MonoBehaviour
{
    public Image lineViewBackground;
    public Image optionsViewBackground;

    [System.Serializable]
    public class ImageCGInfo
    {
        // Audio Name
        public string name;
        // To play music
        public Image image;
    }

    public List<ImageCGInfo> imageList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransparency(Color col)
    {
        lineViewBackground.color = col;
        optionsViewBackground.color = col;
    }

    public void SetTransparencyHalf()
    {
        SetTransparency(new Color(lineViewBackground.color.r, lineViewBackground.color.g, lineViewBackground.color.b, 0.5f));
    }

    public void SetOpaque()
    {
        SetTransparency(new Color(lineViewBackground.color.r, lineViewBackground.color.g, lineViewBackground.color.b, 1f));
    }

    [YarnCommand("ShowCG")]
    public void ShowCGImage(string name)
    {
        SetTransparencyHalf();
        GetCGImage(name).image.gameObject.SetActive(true);
    }

    [YarnCommand("HideCG")]
    public void HideCGImage(string name)
    {
        GetCGImage(name).image.gameObject.SetActive(false);
        SetOpaque();
    }

    public ImageCGInfo GetCGImage(in string imageName)
    {
        string findName = imageName;

        return imageList.Find(image => findName.Equals(image.name));
    }
}
