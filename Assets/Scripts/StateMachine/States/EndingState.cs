using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.EndingView.OnReturnToTitleClicked += ReturnToTileClicked;

        // Show pause view
        owner.UI.CreditsView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.CreditsView.HideView();

        // Detach functions from view events
        owner.UI.EndingView.OnReturnToTitleClicked -= ReturnToTileClicked;

        base.DestroyState();
    }

    /// <summary>
    /// Function called when ReturnToTitle button is clicked in Ending view.
    /// </summary>
    private void ReturnToTileClicked()
    {
        owner.ChangeState(new MenuState { });
    }
}
