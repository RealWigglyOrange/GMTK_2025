using System.Collections.Generic;
using UnityEngine;

public class Doorway_West : MonoBehaviour, IInteractable
{
    [SerializeField] Sprite openSprite;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject openDoorScript;
    public void interact()
    {
        InteractionTree interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();
        Dialogue dialogue1 = new Dialogue("Open the door?", -1, new Option("Yes", openDoorScript), new Option("No"));

        interactionTree.dialogues.Add(dialogue1);
        UserInterface.instance.show(interactionTree);
    }

    public void open()
    {
        spriteRenderer.sprite = openSprite;
        _collider.enabled = false;
    }

    public void triggerInteract()
    {
        throw new System.NotImplementedException();
    }
}
