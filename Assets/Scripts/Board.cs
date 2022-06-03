using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Block blockAsset;
    public Slot slotAsset;
    public GameObject AnswerBlockArea;
    public GameObject PhraseBlockArea;
    public List<Slot> slots;

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
        CreateSlots(slots);
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

    public void CreateSlots(int numberOfSlots)
    {
        for(int i = 0; i < numberOfSlots; i++)
        {
            var newSlot = Instantiate(slotAsset, AnswerBlockArea.transform);
            slots.Add(newSlot);
        }
        //Create and evenly position slots in the slot area based on the number of slots provided
    }
}
