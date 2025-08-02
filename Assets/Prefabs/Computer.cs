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
        Dialogue dialogue1 = new Dialogue("This is text", 1);

        Dialogue dialogue2 = new Dialogue("This is the next text", 2);

        Dialogue dialogue3 = new Dialogue("This is text with options", -1, new Option("Red Pill", 3), new Option("Blue Pill", 4), new Option("Back", 1));

        Dialogue dialogue4 = new Dialogue("You took the red pill", -1);

        Dialogue dialogue5 = new Dialogue("You took the blue pill", -1);


        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);
        interactionTree.dialogues.Add(dialogue3);
        interactionTree.dialogues.Add(dialogue4);
        interactionTree.dialogues.Add(dialogue5);
    }

}
