using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OptionsView : BaseView
{
    // Events to attach to.
    public UnityAction OnResumeClicked;
    public UnityAction OnMenuClicked;

    /// <summary>
    /// Method called by Resume Button.
    /// </summary>
    public void ResumeClick()
    {
        OnResumeClicked?.Invoke();
    }

    /// <summary>
    /// Method called by Menu Button.
    /// </summary>
    public void MenuClick()
    {
        OnMenuClicked?.Invoke();
    }
}
