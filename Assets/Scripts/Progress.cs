using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    // All the variables to hold the players progess in puzzles
    public bool hasKey;

    // Clears the player's progress when they die
    public void clear()
    {
        hasKey = false;
    }
}
