using UnityEngine;

/// <summary>
/// Menu state that show Menu view and add interpret user interaction with that view.
/// </summary>
public class MenuState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.MenuView.OnLoadClicked += LoadClicked;
        owner.UI.MenuView.OnOptionsClicked += OptionsClicked;
        owner.UI.MenuView.OnCreditsClicked += CreditsClicked;
        owner.UI.MenuView.OnQuitClicked += QuitClicked;

        // Show menu view
        owner.UI.MenuView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide menu view
        owner.UI.MenuView.HideView();

        // Detach functions from view events
        owner.UI.MenuView.OnLoadClicked -= LoadClicked;
        owner.UI.MenuView.OnOptionsClicked -= OptionsClicked;
        owner.UI.MenuView.OnCreditsClicked -= CreditsClicked;
        owner.UI.MenuView.OnCreditsClicked -= QuitClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Start button is clicked in Menu view.
    /// </summary>
    private void LoadClicked()
    {
        owner.ChangeState(new LoadState());
    }

    private void OptionsClicked()
    {
        owner.ChangeState(new OptionsState());
    }

    private void CreditsClicked()
    {
        owner.ChangeState(new CreditsState());
    }

    /// <summary>
    /// Function called when Quit button is clicked in Menu view.
    /// </summary>
    private void QuitClicked()
    {
        Application.Quit();
    }

}
