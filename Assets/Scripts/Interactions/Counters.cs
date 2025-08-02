using System.Collections.Generic;
using UnityEngine;

public class Counters : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;

    public int counter = 0;

    void IInteractable.interact()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue = new Dialogue("...");

        if (counter == 5)
        {
            dialogue.text = "THE COUNTERS DON'T DO ANYTHING";
        }

        if (counter == 10)
        {
            dialogue.text = "I ALREADY TOLD YOU THEY DON'T DO ANYTHING. WHY ARE YOU STILL TOUCHING THE COUNTERS";
        }

        interactionTree.dialogues.Add(dialogue);

        UserInterface.instance.show(interactionTree);

        counter++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void IInteractable.triggerInteract()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
