using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Game Over view class.
/// Passes button events and displays score.
/// </summary>
public class GameOverView : BaseView
{
    // Reference to label used for displaying score
    [SerializeField]
    private TextMeshProUGUI scoreLabel;

    // Events to attach to.
    public UnityAction OnReplayClicked;
    public UnityAction OnMenuClicked;

    // Data to display
    public GameResult data;

    public override void ShowView()
    {
        base.ShowView();

        // If we have data, we should display it!
        scoreLabel.text = "Score : " + (data != null ? data.score : 0);
    }

    public override void HideView()
    {
        // Let GC clean memory
        data = null;

        base.HideView();
    }

    /// <summary>
    /// Method called by Replay Button.
    /// </summary>
    public void ReplayClick()
    {
        OnReplayClicked?.Invoke();
    }

    /// <summary>
    /// Method called by Menu Button.
    /// </summary>
    public void MenuClick()
    {
        OnMenuClicked?.Invoke();
    }
}
