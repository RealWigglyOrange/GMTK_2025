using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;
    private Dialogue dialogue;

    [SerializeField] private GameMode GM;
    [SerializeField] private Progress progress;

    public void interact()
    {
        UserInterface.instance.show(interactionTree);

        if (GM.minutes == 9)
        {
            progress.bedroomOpened = true;
        }
    }

    public void triggerInteract()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        dialogue = new Dialogue("It has a small digital clock, but the rest of the oven hasn't worked for a week.");

        interactionTree.dialogues.Add(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.minutes == 9)
        {
            dialogue.text = "You heard a click from the bedroom door.";
        } else
        {
            dialogue.text = "It has a small digital clock, but the rest of the oven hasn't worked for a week.";
        }
    }
}
