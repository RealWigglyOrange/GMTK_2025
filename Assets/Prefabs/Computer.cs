using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;
    public GameObject back;
    public void interact()
    {
        UserInterface.instance.show(interactionTree);
    }
    void Start()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();
        Dialogue dialogue1 = new Dialogue("This is text");

        Dialogue dialogue2 = new Dialogue("This is the next text");

        Dialogue dialogue3 = new Dialogue("This is text with options", new Option("Red Pill"), new Option("Blue Pill"), new Option("Back", back));

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);
        interactionTree.dialogues.Add(dialogue3);
    }

}
