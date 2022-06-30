using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndingView : BaseView
{
    // Events to attach to.
    public UnityAction OnReturnToTitleClicked;

    public void ReturnToTitleClick()
    {
        OnReturnToTitleClicked?.Invoke();
    }

}
