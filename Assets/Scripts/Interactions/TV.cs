using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;

    public void interact()
    {
        UserInterface.instance.show(interactionTree);
    }

    public void triggerInteract()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue = new Dialogue("You really to get your TV fixed. It's been broken for a week.");

        interactionTree.dialogues.Add(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
