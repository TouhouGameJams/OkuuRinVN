using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SentenceBuilderView : BaseView
{
    // Events to attach to.
    public UnityAction OnSentenceBuilderEnded;

    public void SentenceBuilderEnd()
    {
        OnSentenceBuilderEnded?.Invoke();
    }
}
