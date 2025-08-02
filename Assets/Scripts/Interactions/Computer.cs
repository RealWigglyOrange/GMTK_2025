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
        Dialogue dialogue3;

        if (PermenantProgress.hasPCpass)
        {
            dialogue2 = new Dialogue("You remembered your password", new Option("gmtkJameJam2025", 2));
            dialogue3 = new Dialogue("Safe Password: 23 41 6");
            PermenantProgress.hasSafepass = true;
        }
        else
        {
            dialogue2 = new Dialogue("You forgot your password");
            dialogue3 = new Dialogue("...");
        }

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);
        interactionTree.dialogues.Add(dialogue3);

        UserInterface.instance.show(interactionTree);
    }
    public void triggerInteract()
    {
        
    }
    void Start()
    {
        
    }

}
