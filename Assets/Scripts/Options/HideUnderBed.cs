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

    public void execute()
    {
        player.SetActive(false);
        progress.underBed = true;

        cutscene = true;
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
            int nindex = 0;

            if (nindex == 0)
            {
                if (badguy.transform.position != StartNode.transform.position)
                {
                    badguy.transform.position = Vector3.Lerp(badguy.transform.position, StartNode.transform.position, 0.05f);
                } else
                {
                    nindex++;
                }
            } else if (nindex == 1)
            {
                if (badguy.transform.position != Node1.transform.position)
                {
                    badguy.transform.position = Vector3.Lerp(badguy.transform.position, Node1.transform.position, 0.05f);
                }
                else
                {
                    nindex++;
                }
            } else if (nindex == 2)
            {
                if (badguy.transform.position != Node2.transform.position)
                {
                    badguy.transform.position = Vector3.Lerp(badguy.transform.position, Node2.transform.position, 0.05f);
                }
                else
                {
                    nindex++;
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
