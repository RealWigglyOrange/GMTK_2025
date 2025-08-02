using System.Collections.Generic;
using UnityEngine;

public class Couch : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;
    [SerializeField] private Progress progress;

    Dialogue dialogue1;

    public void interact()
    {
        interactionTree.dialogues = new List<Dialogue>();

        if (progress.hasBoards)
        {
            dialogue1 = new Dialogue("There aren't any more floorboards under the couch.", 1);
        } else
        {
            dialogue1 = new Dialogue("You ripped the floorboards out from under the couch.");
        }

        Dialogue dialogue2 = new Dialogue("Not that you need more this loop.");

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);

        UserInterface.instance.show(interactionTree);
        progress.hasBoards = true;
    }

    public void triggerInteract()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionTree = new InteractionTree();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
