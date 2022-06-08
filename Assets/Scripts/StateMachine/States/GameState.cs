using UnityEngine;

/// <summary>
/// This is example of game state.
/// It shows game view and can load some content related to gameplay.
/// </summary>
public class GameState : BaseState
{
    // Variables used for loading and destroying game content
    public bool loadGameContent = true;
    public bool destroyGameContent = true;

    // Used when player decide to go to menu from pause state
    public bool skipToFinish = false;

    public override void PrepareState()
    {
        base.PrepareState();

        owner.UI.GameView.OnSentenceBuilderStarted += SentenceBuilderStart;


        // Attach functions to view events
        //owner.UI.GameView.OnPauseClicked += PauseClicked;
        //owner.UI.GameView.OnFinishClicked += FinishClicked;
        SoundManager soundManager = SoundManager.Instance;
        if (soundManager.IsPlayingBGM())
            soundManager.ResumeBGM();
        // Show game view
        owner.UI.GameView.ShowView();

        if (loadGameContent)
        {
            // here we would load game content
        }
    }

    public override void DestroyState()
    {
        if (destroyGameContent)
        {
            // here we would destroy loaded game content
        }

        //owner.UI.GameView.OnSentenceBuilderStarted -= SentenceBuilderStart;

        // Hide game view


        owner.UI.GameView.HideView();

        owner.UI.GameView.OnSentenceBuilderStarted -= SentenceBuilderStart;

        // Detach functions from view events
        //owner.UI.GameView.OnPauseClicked -= PauseClicked;
        //owner.UI.GameView.OnFinishClicked -= FinishClicked;

        base.DestroyState();
    }

    private void SentenceBuilderStart()
    {
        SoundManager soundManager = SoundManager.Instance;
        if (soundManager.IsPlayingBGM())
            soundManager.PauseBGM();
        soundManager.PlaySFX(soundManager.GetSFX("ThinkStart"));
        soundManager.PlaySBBGM(soundManager.GetBGM("Thinking"));
        owner.ChangeState(new SentenceBuilderState());

    }

    /// <summary>
    /// Function called when Pause button is clicked in Game view.
    /// </summary>
    private void PauseClicked()
    {
        destroyGameContent = false;

        owner.ChangeState(new PauseState());
    }

    /// <summary>
    /// Function called when Finish Game button is clicked in Game view.
    /// </summary>
/*    private void FinishClicked()
    {
        owner.ChangeState(new GameOverState { gameResult = GameResult.GetRandomResult() });
    }*/
}
