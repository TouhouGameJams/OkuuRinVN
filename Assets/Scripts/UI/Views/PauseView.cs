using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Pause view class.
/// Passes button events.
/// </summary>
public class PauseView : BaseView
{
    public UnityAction OnMenuClosed;

    public void MenuClose()
    {
        OnMenuClosed?.Invoke();
    }
}
