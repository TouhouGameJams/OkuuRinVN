using UnityEngine;
using Yarn.Unity;


public class ChangeBG: MonoBehaviour
{
    [Header("Insert BackgroundCanvas")]
    [SerializeField]
    private GameObject[] BackgroundCanvass;
    //0: Chireiden
    //1: HumanVillage

    [YarnCommand("ChangeBG")]
    public void ChangeBGOnCommand(string locationName)
    {
        switch (locationName)
        {
            case "Chireiden":
                BackgroundCanvass[1].SetActive(false);
                BackgroundCanvass[0].SetActive(true);
                break;
            case "HumanVillage":
                BackgroundCanvass[0].SetActive(false);
                BackgroundCanvass[1].SetActive(true);
                break;
        }
    }
}