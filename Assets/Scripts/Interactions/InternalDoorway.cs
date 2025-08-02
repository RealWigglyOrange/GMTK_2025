using UnityEngine;

public class InternalDoorway : MonoBehaviour, IInteractable
{
    [SerializeField] PlayerController player;
    [SerializeField] Sprite oepnDoorSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D _collider;
    public void interact()
    {
        spriteRenderer.sprite = oepnDoorSprite;
        _collider.enabled = false;
        player.interacting = false;
    }

    public void triggerInteract()
    {
        throw new System.NotImplementedException();
    }
}
