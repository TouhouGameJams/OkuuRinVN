using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Block : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Color col;
    public bool isLocked;
    public string itemMessage;
    public int textBoxAnswerNumber;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        //To be decided if we want to make each block a random color
        //GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        
        //Very ugly. Used only to test faster. Must change to get the canvas reference more elegantly
        canvas = transform.parent.parent.parent.GetComponent<Canvas>();

        //Not the best for now
        gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = itemMessage;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isLocked)
        {
            canvasGroup.alpha = 0.5f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isLocked)
        {
            //TODO Block can only be moved within the area of the backgroundImage.
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Event only called if mouse is click upon the object
    }
}
