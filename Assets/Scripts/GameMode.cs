using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private AudioSource knockSFX;

    public float timer;
    public float minutes;

    private float knockCounter = 5;

    void Update()
    {
        if (player.fastForwarding)
        {
            timer += 5 * Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
        }
        minutes = Mathf.Floor(timer / 5);

        if (knockCounter <= 0)
        {
            knockSFX.Stop();
        }
        else
        {
            knockCounter -= Time.deltaTime;
        }

    }
}
