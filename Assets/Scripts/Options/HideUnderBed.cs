using UnityEngine;

public class HideUnderBed : MonoBehaviour, IOption
{
    [SerializeField] GameObject player;
    [SerializeField] Progress progress;

    [SerializeField] SpriteRenderer sr_inDoor;
    [SerializeField] Sprite closedDoor;
    [SerializeField] BoxCollider2D doorColl;

    float counter = 0f;
    bool cutscene = false;

    public void execute()
    {
        player.SetActive(false);
        progress.underBed = true;

        counter = 0f;
        cutscene = true;

        // Run Cutscene

        sr_inDoor.sprite = closedDoor;
        doorColl.enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 5 && cutscene)
        {

        }
    }
}
