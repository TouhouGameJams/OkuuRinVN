using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StartAtNode : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void Start()
    {
        if(NodeData.NodeName != null)
        {
            dialogueRunner.startNode = NodeData.NodeName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
