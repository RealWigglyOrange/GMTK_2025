using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.triggerInteract();

            Destroy(col.attachedRigidbody);
        }
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
