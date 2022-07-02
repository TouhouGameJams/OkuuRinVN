using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CharacterManager: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [YarnCommand("CreateCharacter")]
    public void CreateCharacter(string character, float xPos, float yPos, string standDireciton)
    {
        Dictionary<string, float> directions = new Dictionary<string, float>
        {
            {"Left",1.0f },
            {"Right",-1.0f},
        };
        var newCharacter = Instantiate(Resources.Load("Prefabs/" + character) as GameObject);
        newCharacter.name = character;
        StartCoroutine(newCharacter.GetComponent<CharacterController>().FadeIn());
        newCharacter.transform.position = new Vector3(xPos, yPos, 0);
        newCharacter.transform.localScale = new Vector3(
            directions[standDireciton],
            newCharacter.transform.localScale.y,
            newCharacter.transform.localScale.z
            );
    }

    /*    [YarnCommand("CreateCharacter")]
        public void CreateCharacter(string character, float xPos, float yPos, bool facingRight)
        {
            var newCharacter = Instantiate(Resources.Load("Prefabs/" + character) as GameObject);
            newCharacter.name = character;
            StartCoroutine(newCharacter.GetComponent<CharacterController>().FadeIn());
            newCharacter.transform.position = new Vector3(xPos, yPos, 0);
            if (facingRight)
            {
                newCharacter.transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else
            {
                newCharacter.transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }*/
}
