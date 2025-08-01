using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    // All the variables to hold the players progess in puzzles
    public bool bookshelf;
    public bool boardedWindows;
    public bool safeOpened;
    public bool doorLocked;
    public bool bedroomOpened;
    public bool hasLamp;
    public bool underBed;

    // Clears the player's progress when they die
    public void clear()
    {
        bookshelf = false;
        boardedWindows = false;
        safeOpened = false;
        doorLocked = false;
        bedroomOpened = false;
        hasLamp = false;
        underBed = false;
    }
}
