using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;

    [SerializeField] private GameMode GM;
    [SerializeField] private Progress progress;
    [SerializeField] private GameObject openDoorScript;

    public void interact()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue;

        if (GM.minutes == 5)
        {
            dialogue = new Dialogue("You heard a click from the bedroom door.", new Option("ooo what happened", openDoorScript));
            progress.bedroomOpened = true;
        }
        else
        {
            dialogue = new Dialogue("It has a small digital clock, but the rest of the oven hasn't worked for a week.");
        }

        interactionTree.dialogues.Add(dialogue);
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
