using UnityEngine;

public class InternalDoorway : MonoBehaviour, IInteractable
{
    [SerializeField] PlayerController player;
    [SerializeField] Progress progress;
    [SerializeField] Sprite oepnDoorSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D _collider;

    [SerializeField] GameObject winOption;
    public void interact()
    {
        if (progress.underBed)
        {
            InteractionTree interactionTree = new InteractionTree();
            interactionTree.dialogues = new System.Collections.Generic.List<Dialogue>();

            Dialogue dialogue = new Dialogue("Don't worry about him", new Option("ok", winOption));

            interactionTree.dialogues.Add(dialogue);

            UserInterface.instance.show(interactionTree);
        }
        else
        {
            spriteRenderer.sprite = oepnDoorSprite;
            _collider.enabled = false;
            player.interacting = false;
        }
    }

    public void triggerInteract()
    {
        throw new System.NotImplementedException();
    }
}
