using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Slot : MonoBehaviour, IDropHandler
{
    public bool occupied;

    public string currentText;
    [SerializeField]
    private int slotIndex;

    //DEBUG Purposes mainly
    [SerializeField]
    private string currentMessage;

    //This act as a between stop for the TextBox's answer no inside because I can't access directly
    [SerializeField]
    private int currentTextBoxAnswerNumber;

    //Check if this emptySlot is filled or not
    [SerializeField]
    private bool hasTextBox;

    public int SlotIndex
    {
        get { return slotIndex; }
    }

    public bool HasTextBox
    {
        get { return hasTextBox; }
        set { hasTextBox = value; }
    }

    public int CurrentTextBoxAnswerNumber
    {
        get { return currentTextBoxAnswerNumber; }
        set { currentTextBoxAnswerNumber = value; }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        occupied = true;
        currentText = eventData.pointerDrag.GetComponent<Block>().itemMessage;
        currentMessage = eventData.pointerDrag.GetComponent<Block>().itemMessage;
        currentTextBoxAnswerNumber = eventData.pointerDrag.GetComponent<Block>().textBoxAnswerNumber;
        eventData.pointerDrag.GetComponent<Block>().isLocked = true;

    }
}
