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
    private bool sentenceBuilderStarted;
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
        if(sentenceBuilderStarted)
        {
            if (AreAllSlotsFilled())
            {
                for (int i = 0; i < board.slots.Count; i++)
                {
                    wordList.Add(board.slots[i].currentText);
                }
                CloseBoard();
                sentenceBuilderStarted = false;
            }
        }
    }

    [YarnCommand("SentenceBuilderStart")]
    public void SentenceBuilderStart(string scriptableObjectName)
    {
        //disable and hide continue button
        var sO = Resources.Load<SentenceBuilderScriptableObject>("ScriptableObjects/" + scriptableObjectName);
 
        board.SetUpBoard(sO.numberOfSlots, sO.listPhrases);

        //Show board
        stateMachine.ChangeState(new SentenceBuilderState());
        sentenceBuilderStarted = true;
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
        dR.StartDialogue(outputSentence);
    }

    public string CreateStringFromList()
    {
        return String.Join(" ", wordList);
    }

    public bool AreAllSlotsFilled()
    {
        for (int i = 0; i < board.slots.Count; i++)
        {
            if (board.slots[i].occupied == false)
            {
                return false;
            }
        }
        return true;
    }
}
