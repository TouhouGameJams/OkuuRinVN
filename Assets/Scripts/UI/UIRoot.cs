using UnityEngine;

/// <summary>
/// UI Root class, used for storing references to UI views.
/// </summary>
public class UIRoot : MonoBehaviour
{
    [SerializeField]
    private GameView gameView;
    public GameView GameView => gameView;

    [SerializeField]
    private SentenceBuilderView sentenceBuilderView;
    public SentenceBuilderView SentenceBuilderView => sentenceBuilderView;

    [SerializeField]
    private PauseView pauseView;
    public PauseView PauseView => pauseView;

    [SerializeField]
    private GameOverView gameOverView;
    public GameOverView GameOverView => gameOverView;
}
