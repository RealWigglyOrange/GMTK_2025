using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

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
    public bool interacting;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateSprite();
    }

    void FixedUpdate()
    {
        Movement(Time.fixedDeltaTime);
    }

    void GetInput()
    {
        Vin = Input.GetAxis("Vertical");
        Hin = Input.GetAxis("Horizontal");
        interacting = Input.GetKey(KeyCode.F);
    }

    void UpdateSprite()
    {
        if (Vin > 0)
        {
            spriteRenderer.sprite = bhappy;
        }
        else if (Vin < 0)
        {
            spriteRenderer.sprite = fhappy;
        }
        else if (Hin > 0)
        {
            spriteRenderer.sprite = rhappy;
        }
        else if (Hin < 0)
        {
            spriteRenderer.sprite = lhappy;
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
