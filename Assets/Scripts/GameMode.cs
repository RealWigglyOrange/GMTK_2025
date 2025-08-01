using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    public float timer;
    public float minutes;

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
    }
}
