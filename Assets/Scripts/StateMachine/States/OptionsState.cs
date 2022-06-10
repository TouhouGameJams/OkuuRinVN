using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Stop time in game
        Time.timeScale = 0;

        // Attach functions to view events
        owner.UI.OptionsView.OnMenuClicked += MenuClicked;
        owner.UI.OptionsView.OnResumeClicked += ResumeClicked;

        // Show pause view
        owner.UI.OptionsView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.OptionsView.HideView();

        // Detach functions from view events
        owner.UI.OptionsView.OnMenuClicked -= MenuClicked;
        owner.UI.OptionsView.OnResumeClicked -= ResumeClicked;

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
