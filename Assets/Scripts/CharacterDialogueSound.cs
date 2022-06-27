using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Events;
using System;
using TMPro;

public class CharacterDialogueSound : DialogueViewBase
{
    SoundManager soundManager;

    private string sound;
    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        if (!string.IsNullOrEmpty(dialogueLine.CharacterName))
        {
            // Then notify the rest of the scene about it. This
            // generally involves updating a text view and making it
            // visible.
            switch (dialogueLine.CharacterName)
            {
                case "Okuu":
                    SetSound("TextScrollA");
                    break;
                case "Orin":
                    SetSound("TextScrollB");
                    break;
                case "Satori":
                    SetSound("TextScrollC");
                    break;
            }
        }
        else
        {
            SetSound("TextScrollC");
        }
    }

    public void DialogueSound()
    {
        soundManager.PlaySFXString(sound);
    }

    public void SetSound(string sfx)
    {
        sound = sfx;
    }
}
