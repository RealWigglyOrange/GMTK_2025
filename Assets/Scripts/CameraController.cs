using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    void Update()
    {
        Vector3 position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}
