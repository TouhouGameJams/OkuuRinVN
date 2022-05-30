using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Block blockAsset;
    public Slot slotAsset;
    public GameObject PhraseBlockArea;
    public GameObject AnswerBlockArea;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpBoard(int blocks, int slots, List<string> listStrings)
    {

    }

    public void CreateBlocks(int numberOfBlocks, List<string> listStrings)
    {
        for(int i = 0; i < numberOfBlocks; i++)
        {
            var newGo = Instantiate(blockAsset, PhraseBlockArea.transform);
            
            //Future TODO set up each block message to be read off the list of strings the scriptable object will provide
            //blockAsset.GetComponent<Block>().itemMessage = listStrings[i];

            //TODO set the starting position of each block to be in a random position
            //newGo.transform.position = RandomPointInBounds(new Bounds(new Vector3(0, 0, 0), new Vector3(0, 100, 1)));

        }
    }

    //test function to create blocks individually
    public void CreateBlock(string text)
    {
        var newBlock = Instantiate(blockAsset, PhraseBlockArea.transform);
        blockAsset.GetComponent<Block>().itemMessage = text;
    }

    public void CreateSlots(int numberOfSlots)
    {
        //Create and evenly position slots in the slot area based on the number of slots provided
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0
        );
    }
}
