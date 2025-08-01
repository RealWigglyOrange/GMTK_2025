using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public void interact()
    {
        UserInterface.instance.show("Computer");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
