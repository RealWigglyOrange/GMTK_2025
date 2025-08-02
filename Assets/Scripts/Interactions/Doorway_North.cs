using UnityEngine;
using System.Collections.Generic;

public class Doorway_North : MonoBehaviour, IInteractable
{
    [SerializeField] Sprite openSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject openDoorScript;
    InteractionTree interactionTree;

    public void interact()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();
        Dialogue dialogue1 = new Dialogue("Open the door?", -1, new Option("Yes", openDoorScript), new Option("No", -1));

        interactionTree.dialogues.Add(dialogue1);
        UserInterface.instance.show(interactionTree);
    }

    public void triggerInteract()
    {
        throw new System.NotImplementedException();
    }

    public void open()
    {
        spriteRenderer.sprite = openSprite;
    }
}
