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

        // Skip to finish game
        if (skipToFinish)
        {
            owner.ChangeState(new GameOverState { gameResult = GameResult.GetRandomResult() });
            return;
        }



        SoundManager soundManager = SoundManager.Instance;
        if (soundManager.IsPlayingBGM())
            soundManager.StopBGM();
        soundManager.PlayBGM(soundManager.GetBGM("UnderGround"));


        owner.UI.GameView.OnSentenceBuilderStarted += SentenceBuilderStart;


        // Attach functions to view events
        //owner.UI.GameView.OnPauseClicked += PauseClicked;
        //owner.UI.GameView.OnFinishClicked += FinishClicked;

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
        soundManager.PlaySFX(soundManager.GetSFX("ThinkStart"));

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
