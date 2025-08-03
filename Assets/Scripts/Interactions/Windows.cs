using UnityEngine;
using System.Collections.Generic;

public class Windows : MonoBehaviour, IInteractable
{
    [SerializeField] private Progress progress;
    [SerializeField] private GameObject board;

    public void interact()
    {
        InteractionTree interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue1;
        Dialogue dialogue2 = new Dialogue("9:05");

        if (progress.hasBoards)
        {
            dialogue1 = new Dialogue("Thank god it's locked", new Option("Listen", 1), new Option("Board", board));
        } else
        {
            dialogue1 = new Dialogue("Thank god it's locked", new Option("Listen", 1));
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
