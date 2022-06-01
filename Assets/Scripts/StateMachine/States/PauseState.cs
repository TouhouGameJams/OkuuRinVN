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
        owner.UI.PauseView.OnMenuClicked += MenuClicked;
        owner.UI.PauseView.OnResumeClicked += ResumeClicked;

        // Show pause view
        owner.UI.PauseView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.PauseView.HideView();

        // Detach functions from view events
        owner.UI.PauseView.OnMenuClicked -= MenuClicked;
        owner.UI.PauseView.OnResumeClicked -= ResumeClicked;

        // Resume time in game
        Time.timeScale = 1;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Menu button is clicked in Pause view.
    /// </summary>
    private void MenuClicked()
    {
        // we are using skipToFinish variable to have finishing code in one place - game state
        owner.ChangeState(new GameState { skipToFinish = true });
    }

    /// <summary>
    /// Function called when Resume button is clicked in Pause view.
    /// </summary>
    private void ResumeClicked()
    {
        // we are disabling game content loading as game is already loaded and prepared
        owner.ChangeState(new GameState { loadGameContent = false });
    }

}
