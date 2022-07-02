using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MITState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.MITView.OnCloseClicked += CloseClicked;
        owner.UI.MITView.OnArrowClicked += ArrowClicked;

        // Show pause view
        owner.UI.MITView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.MITView.HideView();

        // Detach functions from view events
        owner.UI.MITView.OnCloseClicked -= CloseClicked;
        owner.UI.MITView.OnArrowClicked -= ArrowClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Menu button is clicked in Pause view.
    /// </summary>
    private void CloseClicked()
    {
        owner.ChangeState(new MenuState { });
    }

    private void ArrowClicked()
    {
        owner.ChangeState(new CreditsState { });
    }
}
