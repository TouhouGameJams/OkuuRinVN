using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SentenceBuilderScriptableObject", order = 1)]
public class SentenceBuilderScriptableObject : ScriptableObject
{
    public int numberOfSlots;
    public List<string> listPhrases;

    public List<string> possibleResults;
}
