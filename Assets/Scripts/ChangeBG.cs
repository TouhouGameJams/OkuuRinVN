using UnityEngine;
using Yarn.Unity;


public class ChangeBG: MonoBehaviour
{
    [Header("Insert BackgroundCanvas")]
    [SerializeField]
    private GameObject[] BackgroundCanvass;
    //0: Chireiden
    //1: HumanVillage
    //2: Sky

    [YarnCommand("ChangeBG")]
    public void ChangeBGOnCommand(string locationName)
    {
        switch (locationName)
        {
            case "Chireiden":
                BackgroundCanvass[0].SetActive(true);
                BackgroundCanvass[1].SetActive(false);
                BackgroundCanvass[2].SetActive(false);
                BackgroundCanvass[3].SetActive(false);
                BackgroundCanvass[4].SetActive(false);
                break;
            case "HumanVillage":
                BackgroundCanvass[0].SetActive(false);
                BackgroundCanvass[1].SetActive(true);
                BackgroundCanvass[2].SetActive(false);
                BackgroundCanvass[3].SetActive(false);
                BackgroundCanvass[4].SetActive(false);
                break;
            case "Sky":
                BackgroundCanvass[0].SetActive(false);
                BackgroundCanvass[1].SetActive(false);
                BackgroundCanvass[2].SetActive(true);
                BackgroundCanvass[3].SetActive(false);
                BackgroundCanvass[4].SetActive(false);
                break;
            case "ChireidenEnding":
                BackgroundCanvass[0].SetActive(false);
                BackgroundCanvass[1].SetActive(false);
                BackgroundCanvass[2].SetActive(false);
                BackgroundCanvass[3].SetActive(true);
                BackgroundCanvass[4].SetActive(false);
                break;
            case "HumanVillageEnding":
                BackgroundCanvass[0].SetActive(false);
                BackgroundCanvass[1].SetActive(false);
                BackgroundCanvass[2].SetActive(false);
                BackgroundCanvass[3].SetActive(false);
                BackgroundCanvass[4].SetActive(true);
                break;
        }
    }
}