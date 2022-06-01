using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public Board board;
    public StateMachine stateMachine;
    public DialogueRunner dR;
    public LineView lW;
    public List<string> wordList;

    private static string outputSentence;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine.ChangeState(new GameState());
    }

    private void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("SentenceBuilderStart")]
    public void SentenceBuilderStart(string scriptableObjectName)
    {
        //disable and hide continue button
        var sO = Resources.Load<SentenceBuilderScriptableObject>("ScriptableObjects/" + scriptableObjectName);
        Debug.Log(sO.listPhrases.Count);
        Debug.Log(sO.numberOfSlots);
        
        foreach(var phrase in sO.listPhrases)
        {
            wordList.Add(phrase);
        }

        //board.CreateBlocks()

        //Show board
        stateMachine.ChangeState(new SentenceBuilderState());

        //Call on board's create slot and block functions using the sO as references
    }

    public void CloseBoard()
    {
        stateMachine.ChangeState(new GameState());
        outputSentence = CreateStringFromList();
        lW.UserRequestedViewAdvancement();
    }

    [YarnFunction("SentenceBuilderResult")]
    public static string OutputToLine()
    {
        return outputSentence;
    }

    [YarnCommand("SentenceBuilderEnd")]
    public void SentenceBuilderEnd()
    {
        dR.Dialogue.Stop();
        dR.StartDialogue("newNode");
    }
    public string CreateStringFromList()
    {
        return String.Join(" ", wordList);
    }
}
