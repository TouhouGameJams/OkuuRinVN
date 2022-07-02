using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AffectionManager : MonoBehaviour
{

    private const int BASE_SCORE = 0;
    private static int m_Score = BASE_SCORE;
    public const int MAX_SCORE = 100;

    public int CurrentScore { get { return m_Score; } }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    ///Add points to Affection Score
    [YarnCommand("AddScore")]
    private void AddScore(int score)
    {
        m_Score += score;
        Debug.Log(m_Score);
        Clamp(ref m_Score, MAX_SCORE);
    }

    [YarnCommand("IsHigher")]
    private bool IsHigher(int conditionScore)
    {
        return conditionScore <= m_Score;
    }

    [YarnFunction("ReturnScore")]
    public static int ReturnScore()
    {
        return m_Score;
    }

    private void Clamp(ref int currentScore,in int maxScore)
    {
        if(maxScore < currentScore)
            currentScore = maxScore;
    }
}
