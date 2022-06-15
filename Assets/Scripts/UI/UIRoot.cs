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

    [SerializeField]
    private MenuView menuView;
    public MenuView MenuView => menuView;

    [SerializeField]
    private LoadView loadView;
    public LoadView LoadView => loadView;

    [SerializeField]
    private OptionsView optionsView;
    public OptionsView OptionsView => optionsView;

    [SerializeField]
    private CreditsView creditsView;
    public CreditsView CreditsView => creditsView;
}
