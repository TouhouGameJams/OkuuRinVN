using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour
{
    private bool m_HasSaveData;
    public bool HasSaveData { get { return m_HasSaveData; } }

    [SerializeField] private GameObject m_ContinueButton;
    // Start is called before the first frame update
    void Start()
    {
        m_HasSaveData = true;
        if (m_HasSaveData == true)
        {
            GameObject startButton = GameObject.Find("StartButton");
            m_ContinueButton.gameObject.SetActive(true);
            startButton.transform.localPosition = new Vector3(
                startButton.transform.localPosition.x,
                -50,
                startButton.transform.localPosition.z
                );

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
