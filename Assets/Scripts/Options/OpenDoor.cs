using UnityEngine;

public class OpenDoor : MonoBehaviour, IOption
{
    [SerializeField] Doorway_North door;

    public void execute()
    {
        door.open();
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
