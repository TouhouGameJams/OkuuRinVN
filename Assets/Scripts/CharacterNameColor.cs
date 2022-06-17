using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Events;
using System;
using TMPro;
public class CharacterNameColor : DialogueViewBase
{
    public Color OkuuCol;
    public Color OrinCol;
    public Color SatoriCol;
    public Color standardCol;
    public TMP_Text text;

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        if (!string.IsNullOrEmpty(dialogueLine.CharacterName))
        {
            // Then notify the rest of the scene about it. This
            // generally involves updating a text view and making it
            // visible.
            switch(dialogueLine.CharacterName)
            {
                case "Okuu":
                    text.color = OkuuCol;
                    break;
                case "Orin":
                    text.color = OrinCol;
                    break;
                case "Satori":
                    text.color = SatoriCol;
                    break;
            }
        }
        else
        {
            text.color = standardCol;
        }
    }
}
