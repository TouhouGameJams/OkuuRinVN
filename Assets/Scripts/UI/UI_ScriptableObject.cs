using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Tween_ScriptableObject/UI_Elements", order = 2)]
public class UI_ScriptableObject: ScriptableObject
{
    [Header("DOTween")]
    [SerializeField]
    private float tweenDuration;

    [SerializeField]
    private bool tweenSnapping;

    [SerializeField]
    private Ease easeType;

    [SerializeField]
    private float tweenDelaySeconds;

    [SerializeField]
    private bool moveHorizontal;

    public bool MoveHorizontal
    {
        get
        {
            return moveHorizontal;
        }
        set
        {
            moveHorizontal = value;
        }
    }

    [SerializeField]
    private bool moveVertical;

    public bool MoveVertical
    {
        get
        {
            return moveVertical;
        }
        set
        {
            moveVertical = value;
        }
    }



    public float TweenDelaySeconds
    {
        get
        {
            return tweenDelaySeconds;
        }
        set
        {
            tweenDelaySeconds = value;
        }
    }


    public float TweenDuration
    {
        get => tweenDuration;
        set => tweenDuration = value;
    }
    public bool TweenSnapping
    {
        get => tweenSnapping;
        set => tweenSnapping = value;
    }
    public Ease EaseType
    {
        get => easeType;
        set => easeType = value;
    }

}