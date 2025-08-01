using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeath : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameMode GM;
    [SerializeField] private Progress Progress;
    [SerializeField] private AudioSource deathSFX;

    private float localTimer = 5;
    public bool isdead = false;

    // Update is called once per frame
    void Update()
    {
        if (GM.timer >= 60)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        isdead = true;
        if (localTimer == 5)
        {
            deathSFX.Play();
        }

        if (player.spriteRenderer.sprite == player.fhappy || player.spriteRenderer.sprite == player.fangry)
        {
            player.spriteRenderer.sprite = player.fdead;
        }
        else if (player.spriteRenderer.sprite == player.bhappy || player.spriteRenderer.sprite == player.bangry)
        {
            player.spriteRenderer.sprite = player.bdead;
        }
        else if (player.spriteRenderer.sprite == player.lhappy || player.spriteRenderer.sprite == player.langry)
        {
            player.spriteRenderer.sprite = player.ldead;
        }
        else if (player.spriteRenderer.sprite == player.rhappy || player.spriteRenderer.sprite == player.rangry)
        {
            player.spriteRenderer.sprite = player.rdead;
        }

        localTimer -= Time.deltaTime;

        if (localTimer <= 0)
        {
            GM.timer = 0;
            Progress.clear();
            player.resetPlayer();
            localTimer = 5;
            isdead = false;
            player.transform.position = new Vector3(0.0f, 0.0f);
        }
    }
}
