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
    private string sound;

    private SoundManager soundManager;
    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        SetNameColor(dialogueLine.CharacterName);
        SetCurrentSpeaker(dialogueLine.CharacterName);
        SetNameSFX(dialogueLine.CharacterName);
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

    private void SetNameSFX(string characterName)
    {
        Dictionary<string, string> characterNameSFX = new Dictionary<string, string>
        {
            {"Okuu","TextScrollA" },
            {"Orin", "TextScrollB" },
            {"Satori", "TextScrollC" },
        };

        if (string.IsNullOrEmpty(characterName))
        {
            SetSound("TextScrollC");
        }
        else if (characterNameSFX.ContainsKey(characterName))
        {
            SetSound(characterNameSFX[characterName]);
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
                spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, 0.75f);
            }

        }
    }
}
