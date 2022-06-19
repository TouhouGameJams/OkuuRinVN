using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Events;
using System;
using TMPro;
public class CurrentSpeaker : DialogueViewBase
{
    public Color OkuuCol;
    public Color OrinCol;
    public Color SatoriCol;
    public Color standardCol;
    public TMP_Text text;

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        SetNameColor(dialogueLine.CharacterName);
        SetCurrentSpeaker(dialogueLine.CharacterName);
    }

    private void SetNameColor(string characterName)
    {
        Dictionary<string, Color> characterNameColor = new Dictionary<string, Color>
        {
            {"Okuu",OkuuCol },
            {"Orin",OrinCol },
            {"Satori",SatoriCol },
        };

        if (string.IsNullOrEmpty(characterName))
        {
            text.color = standardCol;
        }
        else if (characterNameColor.ContainsKey(characterName))
        {
            text.color = characterNameColor[characterName];
        }
    }

    private void SetCurrentSpeaker(string characterName)
    {
        if (string.IsNullOrEmpty(characterName))
            return;

        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        SpriteRenderer spriteRend;
        foreach (GameObject character in characters)
        {
            spriteRend = character.GetComponent<CharacterController>().spriteRend;
            if(character.name == characterName)
            {
                character.transform.position = new Vector3(
                    character.transform.position.x, character.transform.position.y, -1
                    );
                spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, 1.0f);
            }
            else
            {
                character.transform.position = new Vector3(
                    character.transform.position.x, character.transform.position.y, 1
                    );
                spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, 0.5f);
            }

        }
    }
}
