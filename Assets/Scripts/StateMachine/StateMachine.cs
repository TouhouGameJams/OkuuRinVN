using UnityEngine;

// If you wish to learn more about State Machine visit my blog: https://www.patrykgalach.com/2019/03/18/design-pattern-state-machine/

/// <summary>
/// State Machine implementation.
/// Uses BaseState as base class for storing currently operating state.
/// </summary>
public class StateMachine : MonoBehaviour
{
    // Reference to currently operating state.
    private BaseState currentState;

    // Reference to UI root that holds references to different views
    [SerializeField]
    private UIRoot ui;
    public UIRoot UI => ui;

    /// <summary>
    /// Unity method called each frame
    /// </summary>
    private void Update()
    {
        // If we have reference to state, we should update it!
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    /// <summary>
    /// Method used to change state
    /// </summary>
    /// <param name="newState">New state.</param>
    public void ChangeState(BaseState newState)
    {
        // If we currently have state, we need to destroy it!
        if (currentState != null)
        {
            currentState.DestroyState();
        }

        // Swap reference
        currentState = newState;

        // If we passed reference to new state, we should assign owner of that state and initialize it!
        // If we decided to pass null as new state, nothing will happened.
        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }
}

