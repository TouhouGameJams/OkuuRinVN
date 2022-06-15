using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.CreditsView.OnCloseClicked += CloseClicked;

        // Show pause view
        owner.UI.CreditsView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.CreditsView.HideView();

        // Detach functions from view events
        owner.UI.CreditsView.OnCloseClicked -= CloseClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Menu button is clicked in Pause view.
    /// </summary>
    private void CloseClicked()
    {
        owner.ChangeState(new MenuState { });
    }
}
