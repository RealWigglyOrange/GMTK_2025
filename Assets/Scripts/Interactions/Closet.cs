using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    [SerializeField] Progress progress;

    public void interact()
    {
        if (progress.hasLamp)
        {
            InteractionTree interactionTree = new InteractionTree();
            interactionTree.dialogues = new System.Collections.Generic.List<Dialogue>();

            Dialogue dialogue1 = new Dialogue("If you throw the lamp you might get the bad guy's attention", new Option("Throw", 1));
            Dialogue dialogue2 = new Dialogue("I really liked that lamp :(");

            progress.thrownLamp = true;

            interactionTree.dialogues.Add(dialogue1);
            interactionTree.dialogues.Add(dialogue2);

            UserInterface.instance.show(interactionTree);
        } else
        {
            InteractionTree interactionTree = new InteractionTree();
            interactionTree.dialogues = new System.Collections.Generic.List<Dialogue>();

            Dialogue dialogue1 = new Dialogue("Your closet is a perfectly isolated room with only one entrance and exit");

            interactionTree.dialogues.Add(dialogue1);

            UserInterface.instance.show(interactionTree);
        }
    }

    public void triggerInteract()
    {
        throw new System.NotImplementedException();
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
