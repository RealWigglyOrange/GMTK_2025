using UnityEngine;

public class OpenDoor_West : MonoBehaviour, IOption
{
    [SerializeField] Doorway_West door;
    public void execute()
    {
        door.open();
    }
}
