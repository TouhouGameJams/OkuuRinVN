using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    public static DataPersistenceManager instance { get; private set; }
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
