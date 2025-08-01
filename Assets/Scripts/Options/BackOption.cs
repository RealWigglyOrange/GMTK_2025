using UnityEngine;

public class BackOption : MonoBehaviour, IOption
{
    public UserInterface userInterface;
    public void execute()
    {
        Debug.Log("Did a thing");
    }
}
