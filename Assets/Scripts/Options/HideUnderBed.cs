using UnityEngine;

public class HideUnderBed : MonoBehaviour, IOption
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject badguy;
    [SerializeField] Progress progress;

    [SerializeField] SpriteRenderer sr_inDoor;
    [SerializeField] Sprite closedDoor;
    [SerializeField] BoxCollider2D doorColl;

    [SerializeField] GameObject StartNode;
    [SerializeField] GameObject Node1;
    [SerializeField] GameObject Node2;

    bool cutscene = false;
    bool cutend = false;

    int nindex = 0;

    public void execute()
    {
        player.SetActive(false);
        progress.underBed = true;

        cutscene = true;
        badguy.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cutscene)
        {
            if (nindex == 0)
            {
                if (badguy.transform.position.x >= StartNode.transform.position.x - 0.5 && badguy.transform.position.x <= StartNode.transform.position.x + 0.5 && badguy.transform.position.y >= StartNode.transform.position.y - 0.5 && badguy.transform.position.y <= StartNode.transform.position.y + 0.5)
                {
                    nindex++;
                } else
                {
                    badguy.transform.position = Vector3.Lerp(badguy.transform.position, StartNode.transform.position, 0.5f);
                }
            } else if (nindex == 1)
            {
                if (badguy.transform.position.x >= Node1.transform.position.x - 0.5 && badguy.transform.position.x <= Node1.transform.position.x + 0.5 && badguy.transform.position.y >= Node1.transform.position.y - 0.5 && badguy.transform.position.y <= Node1.transform.position.y + 0.5)
                {
                    nindex++;
                }
                else
                {
                    badguy.transform.position = Vector3.Lerp(badguy.transform.position, Node1.transform.position, 0.01f);
                }
            } else if (nindex == 2)
            {
                if (badguy.transform.position.x >= Node2.transform.position.x - 0.5 && badguy.transform.position.x <= Node2.transform.position.x + 0.5 && badguy.transform.position.y >= Node2.transform.position.y - 0.5 && badguy.transform.position.y <= Node2.transform.position.y + 0.5)
                {
                    nindex++;
                }
                else
                {
                    badguy.transform.position = Vector3.Lerp(badguy.transform.position, Node2.transform.position, 0.01f);
                }
            } else
            {
                cutend = true;
            }
        }

        if (cutend)
        {
            sr_inDoor.sprite = closedDoor;
            doorColl.enabled = true;

            player.SetActive(true);
        }
    }
}
