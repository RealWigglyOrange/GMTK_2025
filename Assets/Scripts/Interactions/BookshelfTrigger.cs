using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.triggerInteract();
            Destroy(collision.attachedRigidbody);
            Destroy(this.gameObject);
        }
    }
}
