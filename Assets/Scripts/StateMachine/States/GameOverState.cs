using UnityEngine;

/// <summary>
/// This is example of game over state.
/// It shows how you can handle data with game result and display it in UI view.
/// </summary>
public class GameOverState : BaseState
{
    // Data with information about game result
    public GameResult gameResult;

    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.GameOverView.OnReplayClicked += ReplayClicked;
        owner.UI.GameOverView.OnMenuClicked += MenuClicked;

        // Pass data to display it in UI
        owner.UI.GameOverView.data = gameResult;

        // Show summary view
        owner.UI.GameOverView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide summary view
        owner.UI.GameOverView.HideView();

        // Detach functions from view events
        owner.UI.GameOverView.OnReplayClicked -= ReplayClicked;
        owner.UI.GameOverView.OnMenuClicked -= MenuClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Replay button is clicked in Game Over / Summary view.
    /// </summary>
    private void ReplayClicked()
    {
        owner.ChangeState(new GameState());
    }

    /// <summary>
    /// Function called when Menu button is clicked in Game Over / Summary view.
    /// </summary>
    private void MenuClicked()
    {
        //owner.ChangeState(new MenuState());
    }

}
