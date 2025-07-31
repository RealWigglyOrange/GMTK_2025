using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float Vin;
    private float Hin;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vin = Input.GetAxis("Vertical");
        Hin = Input.GetAxis("Horizontal");

        transform.position += Vector3.Normalize(new Vector3(Hin, Vin)) * speed * Time.deltaTime;
    }
}
