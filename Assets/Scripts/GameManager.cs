using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject backgroundImage;
    public Board board;
    public StateMachine stateMachine;
    public UIRoot uiRoot;
    public DialogueRunner dR;
    public LineView lW;
    public List<string> wordList;

    public SentenceBuilderScriptableObject currentSO;
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
                wordList = new List<string>();
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
        currentSO = Resources.Load<SentenceBuilderScriptableObject>("ScriptableObjects/" + scriptableObjectName);

        board.SetUpBoard(currentSO.numberOfSlots, currentSO.listPhrases);

        //Show board
        uiRoot.GameView.SentenceBuilderStart();
        //stateMachine.ChangeState(new SentenceBuilderState());
        sentenceBuilderStarted = true;

        Animator anim = GameObject.Find("DialogueSystem").GetComponentInChildren<Animator>();
        anim.Play("OpenWindow");
    }        //Call on board's create slot and block functions using the sO as references

    public void CloseBoard()
    {

        //We need to wait a second to see the close anim
        Animator anim = GameObject.Find("DialogueSystem").GetComponentInChildren<Animator>();
        anim.Play("CloseWindow");
        board.CleanBoard();
        // Animation End
        uiRoot.SentenceBuilderView.SentenceBuilderEnd();


        //stateMachine.ChangeState(new GameState());
        nodeName = ValidateNode();
        lW.UserRequestedViewAdvancement();
    }

    public void CleanBoard()
    {
        foreach(Transform child in board.AnswerBlockArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in board.PhraseBlockArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    [YarnFunction("JumpToNode")]
    public static string JumpToNode()
    {
        return nodeName;
    }

    public string ValidateNode()
    {
        foreach(var answer in currentSO.SentenceAnswerList)
        {
            if (Enumerable.SequenceEqual(answer.outputComparatorList, wordList))
            {
                return answer.nodeName;
            }
        }
        return currentSO.invalidNodeName;
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

    public void PauseMenu()
    {
        uiRoot.GameView.PauseClick();

    }
}