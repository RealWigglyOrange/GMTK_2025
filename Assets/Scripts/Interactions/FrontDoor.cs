using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FrontDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Progress progress;

    public void interact()
    {
        InteractionTree interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue1;

        if (progress.bookshelf || progress.doorLocked)
        {
            dialogue1 = new Dialogue("...");
        } else
        {
            dialogue1 = new Dialogue("You can here someone outside your door trying to get inside", new Option("Offer Tea", 1), new Option("Diplomacy", 2));
        }

        Dialogue dialogue2 = new Dialogue("You: Would you like some tee?", 3);
        Dialogue dialogue3 = new Dialogue("You: Is there any particular reason you're trying to brutally murder me?", 3);

        Dialogue dialogue4 = new Dialogue("Shadow Man: gmtkJameJam2025");

        PermenantProgress.hasPCpass = true;

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);
        interactionTree.dialogues.Add(dialogue3);
        interactionTree.dialogues.Add(dialogue4);

        UserInterface.instance.show(interactionTree);
    }

    public void triggerInteract()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
