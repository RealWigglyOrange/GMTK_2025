using UnityEngine;

public class Win : MonoBehaviour, IOption
{
    [SerializeField] GameObject winText;

    public void execute()
    {
        winText.SetActive(true);
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
