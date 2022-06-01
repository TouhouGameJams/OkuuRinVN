using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Menu view class.
/// Passes button events.
/// </summary>
public class MenuView : BaseView
{
    // Events to attach to.
    public UnityAction OnStartClicked;
    public UnityAction OnQuitClicked;

    /// <summary>
    /// Method called by Start Button.
    /// </summary>
    public void StartClick()
    {
        OnStartClicked?.Invoke();
    }

    /// <summary>
    /// Method called by Quit Button.
    /// </summary>
    public void QuitClick()
    {
        OnQuitClicked?.Invoke();
    }
}
