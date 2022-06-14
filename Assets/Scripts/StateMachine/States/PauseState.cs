using UnityEngine;

/// <summary>
/// This is example of pause state.
/// It shows how you can implement pause menu as different state then game state.
/// </summary>
public class PauseState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Stop time in game
        Time.timeScale = 0;

        // Attach functions to view events
        owner.UI.PauseView.OnMenuClosed += MenuClosed;

        // Show pause view
        owner.UI.PauseView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.PauseView.HideView();

        // Detach functions from view events
        owner.UI.PauseView.OnMenuClosed -= MenuClosed;

        // Resume time in game
        Time.timeScale = 1;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Menu button is clicked in Pause view.
    /// </summary>
    private void MenuClosed()
    {
        // we are using skipToFinish variable to have finishing code in one place - game state
        owner.ChangeState(new GameState {});
    }
}
