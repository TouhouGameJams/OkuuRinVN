using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsView : BaseView
{
    // Events to attach to.
    public UnityAction OnCloseClicked;

    public void CloseClick()
    {
        OnCloseClicked?.Invoke();
    }
}
