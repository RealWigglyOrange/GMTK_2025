using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;
    public GameObject back;
    public TextAsset textAsset;

    public void interact()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();
        Dialogue dialogue1 = new Dialogue("...", 1);

        Dialogue dialogue2;

        if (PermenantProgress.hasPCpass)
        {
            Debug.Log("has pc pass");
            dialogue2 = new Dialogue("You remembered your password", new Option("gmtkJameJam2025", -1));
        }
        else
        {
            dialogue2 = new Dialogue("You forgot your password");
        }

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);

        UserInterface.instance.show(interactionTree);
    }
    public void triggerInteract()
    {
        
    }
    void Start()
    {
        
    }

}
