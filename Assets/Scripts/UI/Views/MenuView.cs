using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Menu view class.
/// Passes button events.
/// </summary>
public class MenuView : BaseView
{
    // Events to attach to.
    public UnityAction OnLoadClicked;
    public UnityAction OnOptionsClicked;
    public UnityAction OnCreditsClicked;
    public UnityAction OnQuitClicked;

    public void LoadClick()
    {
        OnLoadClicked?.Invoke();
    }

    public void OptionsClick()
    {
        OnOptionsClicked?.Invoke();
    }

    public void CreditsClick()
    {
        OnCreditsClicked?.Invoke();
    }

    public void QuitClick()
    {
        OnQuitClicked?.Invoke();
    }
}
