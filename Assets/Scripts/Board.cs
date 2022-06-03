using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void SetUpBoard(int slots, List<string> listStrings)
    {
        CreateBlocks(listStrings);
    }

    public void CreateBlocks(List<string> listStrings)
    {
        var positions = new List<Vector3>();
        for(int i = 0; i < listStrings.Count; i++)
        {
            Vector3 position;

            do
            {
                position = new Vector3(
                                Random.Range(-750f, 750f),
                                Random.Range(-275f, 275f),
                                0f);
            } while (positions.Any(p => Vector3.Distance(position, p) < blockAsset.GetComponent<RectTransform>().rect.width));

            positions.Add(position);

            var newGo = Instantiate(blockAsset, PhraseBlockArea.transform);
            blockAsset.itemMessage = listStrings[i];
            newGo.transform.localPosition = positions[i];
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

    public Vector3 GeneratedPosition()
    {
        var screenToWorldPosition = Camera.main.ScreenToWorldPoint(PhraseBlockArea.GetComponent<RectTransform>().transform.position);
        float x, y, z;
        x = Random.Range(-750f, 750f);
        y = Random.Range(-275f, 275f);
        z = 0;
        return new Vector3(x, y, z);
    }
}
