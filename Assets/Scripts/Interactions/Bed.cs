using UnityEngine;
using System.Collections.Generic;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] private DetectDeath death;
    [SerializeField] private Progress progress;
    [SerializeField] private GameObject kill;
    [SerializeField] private GameObject hide;

    public void interact()
    {
        InteractionTree interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue1 = new Dialogue("What do you want to do?", new Option("Sleep", 1), new Option("Hide", 2));
        Dialogue dialogue2 = new Dialogue("That's a really bad idea.");
        Dialogue dialogue3;

        if (progress.thrownLamp)
        {
            dialogue3 = new Dialogue("Are you ready? All you have to do is lock the closet door.", new Option("yes", hide));
        } else
        {
            dialogue3 = new Dialogue("He found you", new Option("oh", kill));
        }

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);
        interactionTree.dialogues.Add(dialogue3);

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
