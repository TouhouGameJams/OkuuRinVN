using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AffectionManager : MonoBehaviour
{

    private const int BASE_SCORE = 10;
    private int m_Score = BASE_SCORE;
    public int CurrentScore { get { return m_Score; } }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [YarnCommand("AddScore")]
    private void AddScore(int score)
    {
        m_Score += score;
        Debug.Log(m_Score);
    }

    [YarnCommand("IsHigher")]
    private bool IsHigher(int conditionScore)
    {
        return conditionScore <= m_Score;
    }

}
