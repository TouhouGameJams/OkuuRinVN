using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{
    public Block blockAsset;
    public Slot slotAsset;
    public GameObject AnswerBlockArea;
    public GameObject PhraseBlockArea;
    public List<Slot> slots;
    private float[] slotPosition = { -600f, -300f, 0f, 300f, 600f };
    private float[] slotPositionEven = { -400f, -100f, 100f, 400f };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetUpBoard(in int slots, in List<string> listStrings)
    {
        CreateBlocks(listStrings);
        CreateSlots(slots);
    }

    public void CreateBlocks(List<string> listStrings)
    {
        var positions = new List<Vector3>();
        Vector3 position;
        for (int i = 0; i < listStrings.Count; i++)
        {
            do
            {
                position = new Vector3(
                                Random.Range(-750f, 750f),
                                Random.Range(-275f, 275f),
                                0f);
            } while (positions.Any(p => Vector3.Distance(position, p) < blockAsset.GetComponent<RectTransform>().rect.width));

            positions.Add(position);

            var newGo = Instantiate(blockAsset, PhraseBlockArea.transform);
            newGo.itemMessage = listStrings[i];
            newGo.transform.localPosition = positions[i];
        }
    }

    public void CreateSlots(int numberOfSlots)
    {
        const float SPACING_WIDTH = 50f;
        float SLOT_WIDTH = slotAsset.GetComponent<RectTransform>().rect.width;

        if(numberOfSlots%2 == 0)
        {
            for (int i = 0; i < numberOfSlots; i++)
            {
                float xPos = slotPositionEven[1] + (SLOT_WIDTH * (i - 1)) + (SPACING_WIDTH * (i - 1));
                var newSlot = Instantiate(slotAsset, AnswerBlockArea.transform);
                newSlot.transform.localPosition = new Vector3(xPos, 0f, 0f);
                var slotNumber = 1 + i;
                newSlot.GetComponentInChildren<TextMeshProUGUI>().text = "Slot " + slotNumber.ToString();
                newSlot.SlotIndex = i;
                slots.Add(newSlot);
            }
        }
        else
        {
            for (int i = 0; i < numberOfSlots; i++)
            {
                float xPos = slotPosition[numberOfSlots - 1] + (SLOT_WIDTH * (i - 1)) + (SPACING_WIDTH * (i - 1));
                var newSlot = Instantiate(slotAsset, AnswerBlockArea.transform);
                newSlot.transform.localPosition = new Vector3(xPos, 0f, 0f);
                var slotNumber = 1 + i;
                newSlot.GetComponentInChildren<TextMeshProUGUI>().text = "Slot " + slotNumber.ToString();
                newSlot.SlotIndex = i;
                slots.Add(newSlot);
            }
        }


        //Create and evenly position slots in the slot area based on the number of slots provided
    }

    public void CleanBoard()
    {
        foreach (Transform child in AnswerBlockArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in PhraseBlockArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        slots = new List<Slot>();

    }
}
