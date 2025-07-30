using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] public float timer;

    void Update()
    {
        timer += Time.deltaTime;
    }
}
