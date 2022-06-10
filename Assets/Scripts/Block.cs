using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Block : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Color col;
    public bool isLocked;
    public string itemMessage;
    public int textBoxAnswerNumber;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image backGroundImage;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        //To be decided if we want to make each block a random color
        //GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        canvas = GetComponentInParent<Canvas>();
        backGroundImage = GetComponentInParent<Image>();
        //Not the best for now
        GetComponentInChildren<TextMeshProUGUI>().text = itemMessage;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Grab"));

        if (!isLocked)
        {
            canvasGroup.alpha = 0.5f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //SoundManager soundManager = SoundManager.Instance;
        //soundManager.PlaySFX(soundManager.GetSFX("Grab"));

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
            //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Drop"));

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
