using System.Collections.Generic;
using UnityEngine;

public class CoffeeTable : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;

    void IInteractable.interact()
    {
        UserInterface.instance.show(interactionTree);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue = new Dialogue("You're coffee tastes like **** now. It's been sitting there for a week.");

        interactionTree.dialogues.Add(dialogue);
    }

    void IInteractable.triggerInteract()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
