using UnityEngine;
using System.Collections.Generic;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] private Progress progress;
    [SerializeField] private GameObject go;
    [SerializeField] BoxCollider2D nightstand;

    public void interact()
    {
        InteractionTree interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();

        Dialogue dialogue = new Dialogue("You pick up the lamp");
        go.SetActive(false);
        nightstand.enabled = true;
        progress.hasLamp = true;

        interactionTree.dialogues.Add(dialogue);
        UserInterface.instance.show(interactionTree);
    }

    public void triggerInteract()
    {
        
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
