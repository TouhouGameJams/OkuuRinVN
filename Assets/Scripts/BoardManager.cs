using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BoardManager : MonoBehaviour
{
    public Board board;
    public DialogueRunner dR;
    public LineView lW;
    public List<string> wordList;
    private static string outputSentence;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //validate whether all the slots are filled
        //FinishBoard();
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SentenceBuilderEnd();
        }
    }

    public void SentenceBuilderStart(string scriptableObjectName)
    {
        //disable and hide continue button

        var sO = Resources.Load<SentenceBuilderScriptableObject>("ScriptableObjects/" + scriptableObjectName);
        //Debug.Log(sO.numberOfBlocks);
        Debug.Log(sO.numberOfSlots);

        //Show board

        //Call on board's create slot and block functions using the sO as references
    }

    public void SentenceBuilderEnd()
    {
        outputSentence = CreateStringFromList();
        lW.UserRequestedViewAdvancement();
    }

    public void FinishBoard()
    {
        outputSentence = CreateStringFromList();
    }



    public void Test()
    {
        dR.Dialogue.Stop();
        dR.StartDialogue("newNode");
    }

    public static string OutputToLine()
    {
        return outputSentence;
    }
    public string CreateStringFromList()
    {
        return String.Join(" ", wordList);
    }
}
