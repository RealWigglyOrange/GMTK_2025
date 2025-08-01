using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite fhappy;
    public Sprite bhappy;
    public Sprite fdead;
    public Sprite bdead;
    public Sprite fangry;
    public Sprite bangry;

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


        if (Vin > 0)
        {
            spriteRenderer.sprite = bhappy;
        } else if (Vin < 0)
        {
            spriteRenderer.sprite = fhappy;
        }
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
