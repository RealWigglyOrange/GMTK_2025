using UnityEngine;
using System.Collections.Generic;

public class Safe : MonoBehaviour, IInteractable
{
    [SerializeField] private Progress progress;

    public void interact()
    {
        InteractionTree interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue1;
        Dialogue dialogue2;

        if (PermenantProgress.hasSafepass)
        {
            dialogue1 = new Dialogue("Input the passcode", new Option("23 41 6", 1));
            dialogue2 = new Dialogue("You got a lock");
            progress.safeOpened = true;
        } else
        {
            dialogue1 = new Dialogue("You forgot your passcode. I think it's saved on the computer tho");
            dialogue2 = new Dialogue("How? I'm not mad. I'm just... HOW?");
        }

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);

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
