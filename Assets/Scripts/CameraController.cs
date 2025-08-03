using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Progress progress;

    void Update()
    {
        if (progress.bedroomOpened)
        {
            Vector3 position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, position, 0.2f);
        }
    }
}
