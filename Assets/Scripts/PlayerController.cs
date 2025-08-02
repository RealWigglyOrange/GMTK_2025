using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
    public SpriteRenderer spriteRenderer;
    [SerializeField] private DetectDeath death;

    [Header("Sprites")]
    public Sprite fhappy;
    public Sprite bhappy;
    public Sprite lhappy;
    public Sprite rhappy;
    public Sprite fdead;
    public Sprite bdead;
    public Sprite ldead;
    public Sprite rdead;
    public Sprite fangry;
    public Sprite bangry;
    public Sprite langry;
    public Sprite rangry;

    private float Vin;
    private float Hin;
    public bool tryInteract;
    public bool interacting;
    public bool fastForwarding;
    public Direction direction;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!death.isdead && !interacting)
        {
            GetInput();
            GetDirection();
            UpdateSprite();
            TryInteract();
        } else
        {
            fastForwarding = false;
        }
    }

    void FixedUpdate()
    {
        if (!death.isdead && !interacting)
        {
            Movement(Time.fixedDeltaTime);
        }
    }

    void GetInput()
    {
        Vin = Input.GetAxis("Vertical");
        Hin = Input.GetAxis("Horizontal");
        tryInteract = Input.GetKeyDown(KeyCode.F);
        // FOR THE LOVE OF GOD DON'T CHANGE HOW THIS CODE WORKS
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fastForwarding = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fastForwarding = false;
        }
    }

    void UpdateSprite()
    {
        switch (direction)
        {
            case Direction.North:
                spriteRenderer.sprite = bhappy;
                break;
            case Direction.South:
                spriteRenderer.sprite = fhappy;
                break;
            case Direction.East:
                spriteRenderer.sprite = rhappy;
                break;
            case Direction.West:
                spriteRenderer.sprite = lhappy;
                break;
        }
    }

    void GetDirection()
    {
        if (Vin > 0)
        {
            direction = Direction.North;
        }
        else if (Vin < 0)
        {
            direction = Direction.South;
        }
        else if (Hin > 0)
        {
            direction = Direction.East;
        }
        else if (Hin < 0)
        {
            direction = Direction.West;
        } 
    }

    void TryInteract()
    {
        if (tryInteract)
        {
            Vector2 castDirection = Vector2.zero;
            switch (direction)
            {
                case Direction.North:
                    castDirection = Vector2.up;
                    break;
                case Direction.South:
                    castDirection = Vector2.down;
                    break;
                case Direction.East:
                    castDirection = Vector2.right;
                    break;
                case Direction.West:
                    castDirection = Vector2.left;
                    break;
            }
            RaycastHit2D hit = Physics2D.Raycast(transform.position, castDirection, 1.0f);
            if (hit)
            {
                if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.interact();
                    interacting = true;
                }
            }
        }
    }

    void Movement(float t)
    {
        transform.position += Vector3.Normalize(new Vector3(Hin, Vin)) * speed * t;
    }

    public void resetPlayer()
    {
        // reset position, sprite
        spriteRenderer.sprite = fhappy;
    }
}
