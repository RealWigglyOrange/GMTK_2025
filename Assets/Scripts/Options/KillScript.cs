using UnityEngine;

public class KillScript : MonoBehaviour, IOption
{
    [SerializeField] private DetectDeath death;

    public void execute()
    {
        death.killPlayer();
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
