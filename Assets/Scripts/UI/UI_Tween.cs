using System.Collections;
using DG.Tweening;
using UnityEngine;


public class UI_Tween: MonoBehaviour
{
    [Header("UI_SO to access Tween value")]
    [SerializeField]
    private UI_ScriptableObject _UI_ScriptableObject;

    [Header("Objects to be tween")]
    [SerializeField]
    private RectTransform myUI_Rect;
    private float currentTweenDelay;

    [Header("_READ_ONLY > Press T to tess MoveUIBackToOG")]
    [SerializeField]
    private RectTransform myGoal_Rect;
    [SerializeField]
    private Vector2 myUI_OGPos;

    void Start()
    {
        myUI_OGPos = myUI_Rect.anchoredPosition;
        myGoal_Rect = this.GetComponent<RectTransform>();
        currentTweenDelay = _UI_ScriptableObject.TweenDelaySeconds;

        if (_UI_ScriptableObject.MoveHorizontal)
        {
            StartCoroutine(DelayTween_MoveUIRight());
        }

        else if (_UI_ScriptableObject.MoveVertical)
        {
            StartCoroutine(DelayTween_MoveUIDown());
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //MoveUIBackToOG();
        }
    }

    public void MoveUIBackToOG()
    {
        myUI_Rect.DOAnchorPosX(myUI_OGPos.x,
            _UI_ScriptableObject.TweenDuration,
            _UI_ScriptableObject.TweenSnapping);
    }

    private IEnumerator DelayTween_MoveUIRight()
    {
        //Check for delay first then Tween
        yield return new WaitForSeconds(currentTweenDelay);
        myUI_Rect.DOAnchorPosX(myGoal_Rect.anchoredPosition.x,
            _UI_ScriptableObject.TweenDuration,
            _UI_ScriptableObject.TweenSnapping);
    }

    private IEnumerator DelayTween_MoveUIDown()
    {
        //Check for delay first then Tween
        yield return new WaitForSeconds(currentTweenDelay);
        myUI_Rect.DOAnchorPosY(myGoal_Rect.anchoredPosition.y,
            _UI_ScriptableObject.TweenDuration,
            _UI_ScriptableObject.TweenSnapping);
    }
}