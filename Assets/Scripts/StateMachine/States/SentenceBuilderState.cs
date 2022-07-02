using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceBuilderState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        owner.UI.SentenceBuilderView.OnSentenceBuilderEnded += SentenceBuilderEnd;

        // Show pause view
        owner.UI.SentenceBuilderView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide pause view
        owner.UI.SentenceBuilderView.HideView();

        owner.UI.SentenceBuilderView.OnSentenceBuilderEnded -= SentenceBuilderEnd;

        base.DestroyState();
    }

    private void ReturnGameState()
    {
        // we are disabling game content loading as game is already loaded and prepared
        owner.ChangeState(new GameState { loadGameContent = false });
    }

    private void SentenceBuilderEnd()
    {
        SoundManager soundManager = SoundManager.Instance;
        soundManager.PlaySFX(soundManager.GetSFX("Confirm"));
        soundManager.StopSBBGM();
        soundManager.ResumeBGM();
        owner.ChangeState(new GameState());
    }

    private void OptionsState()
    {

    }
}
