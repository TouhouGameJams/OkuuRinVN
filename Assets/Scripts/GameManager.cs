using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public Board board;
    public StateMachine stateMachine;
    public UIRoot uiRoot;
    public DialogueRunner dR;
    public LineView lW;
    public List<string> wordList;

    public List<string> nodeList;
    private static string nodeName;
    private bool sentenceBuilderStarted;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.Instance;
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
                foreach (Slot slot in board.slots)
                {
                    wordList.Add(slot.currentText);
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

        CreateList(sO.possibleResults);
        //Show board
        uiRoot.GameView.SentenceBuilderStart();
        //stateMachine.ChangeState(new SentenceBuilderState());
        sentenceBuilderStarted = true;

        Animator anim = GameObject.Find("Dialogue System").GetComponentInChildren<Animator>();
        anim.Play("OpenWindow");
    }        //Call on board's create slot and block functions using the sO as references

    public void CloseBoard()
    {
        Animator anim = GameObject.Find("Dialogue System").GetComponentInChildren<Animator>();
        anim.Play("CloseWindow");
        // Animation End
        uiRoot.SentenceBuilderView.SentenceBuilderEnd();


        //stateMachine.ChangeState(new GameState());
        nodeName = ValidateNode();
        lW.UserRequestedViewAdvancement();
    }

    [YarnFunction("JumpToNode")]
    public static string JumpToNode()
    {
        return nodeName;
    }

    public string ValidateNode()
    {
        var word = String.Join("_", wordList);
        if (nodeList.Contains(word))
        {
            return word;
        }
        return "Invalid";
    }

    public string CheckSlots(List<String> list, string keyWord)
    {
        if(list.Contains(keyWord))
        {
            return keyWord;
        }
        return "Invalid";
        //wordList.Find(x => wordList.Contains(keyWord));
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

    public void CreateList(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            nodeList.Add(list[i]);
        }
    }
}