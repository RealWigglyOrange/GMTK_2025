using UnityEngine;

public class OpenDoor : MonoBehaviour, IOption
{
    [SerializeField] Doorway_North door;

    public void execute()
    {
        door.open();
    }
}
