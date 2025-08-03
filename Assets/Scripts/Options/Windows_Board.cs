using UnityEngine;

public class Windows_Board : MonoBehaviour, IOption
{
    [SerializeField] private SpriteRenderer lWindow;
    [SerializeField] private SpriteRenderer rWindow;
    [SerializeField] private Sprite boardedWindow;

    [SerializeField] private Progress progress;

    public void execute()
    {
        lWindow.sprite = boardedWindow;
        rWindow.sprite = boardedWindow;
        progress.boardedWindows = true;
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
