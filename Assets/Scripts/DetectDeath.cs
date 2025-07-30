using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeath : MonoBehaviour
{
    [SerializeField] private GameMode GM;
    [SerializeField] private Progress Progress;

    // Update is called once per frame
    void Update()
    {
        if (GM.timer >= 180)
        {
            Debug.Log("You Died");
            GM.timer = 0;
            Progress.clear();
        }
    }
}
