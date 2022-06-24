using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SaveDataManager : MonoBehaviour
{
    //===== Begin of Singleton Feature =====//

    private static SaveDataManager instance;

    public static SaveDataManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (instance == null)
            {
                Debug.Log("Instance Error in SoundManager.");
            }
        }

        GameObject[] objects = GameObject.FindGameObjectsWithTag("SaveDataManager");
        if (1 < objects.Length)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

    }

    //===== End of Singleton Feature =====//

    private bool m_hasSaveData = false;
    public bool HasSaveData { get { return m_hasSaveData; } }

    [System.Serializable]
    public struct SaveData
    {
        public string lastSentence;
        public string resolution;
        public bool isFullScreen;
        public float bgmVolume;
        public float sfxVolume;
    }

    public SaveData m_saveData;
    /*[SerializeField] private GameObject m_continueButton*/
    [SerializeField] private GameObject m_continueButton;
    // Start is called before the first frame update
    void Start()
    {
        if (m_saveData.ToString().Equals(string.Empty))
        {
            m_hasSaveData = false;
        }
        else
        {
            m_hasSaveData = true;
            LoadInfo();
        }

        if (m_hasSaveData == true)
        {

/*            GameObject startButton = GameObject.Find("StartButton");
            m_continueButton.gameObject.SetActive(true);
            startButton.transform.localPosition = new Vector3(
                startButton.transform.localPosition.x,
                -50,
                startButton.transform.localPosition.z
                );
*/
        }


    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI text = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void SaveInfo()
    {
        m_saveData.lastSentence = PlayerPrefs.GetString("LastSentence");
        m_saveData.bgmVolume = PlayerPrefs.GetFloat("BGM");
        m_saveData.sfxVolume = PlayerPrefs.GetFloat("SFX");
        m_saveData.resolution = PlayerPrefs.GetString("Resolution");

        StreamWriter writer = new StreamWriter("Assets/UserData/SaveData.json", false);

        string jsonString = JsonUtility.ToJson(m_saveData);
        writer.Write(jsonString);
        writer.Flush();
        writer.Close();
    }

    public void SaveBGM()
    {
        m_saveData.bgmVolume = PlayerPrefs.GetFloat("BGM");
        StreamWriter writer = new StreamWriter("Assets/UserData/SaveData.json", false);
        string jsonString = JsonUtility.ToJson(m_saveData);
        writer.Write(jsonString);
        writer.Flush();
        writer.Close();
    }

    public void SaveSFX()
    {
        m_saveData.bgmVolume = PlayerPrefs.GetFloat("SFX");
        StreamWriter writer = new StreamWriter("Assets/UserData/SaveData.json", false);
        string jsonString = JsonUtility.ToJson(m_saveData);
        writer.Write(jsonString);
        writer.Flush();
        writer.Close();
    }

    public SaveData LoadInfo()
    {
        if (m_saveData.ToString().Equals(string.Empty))
        {
            StreamReader reader = new StreamReader("Assets/UserData/SaveData.json", false);
            string saveDataString = reader.ReadToEnd();
            SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataString);
            m_saveData = saveData;
        }
        return m_saveData;
    }
}
