using UnityEngine;

public class Bookshelf : MonoBehaviour, IInteractable
{
    public void interact()
    {
        InteractionTree tree = new InteractionTree();
        Dialogue dialogue1 = new Dialogue("Do you want to read?", new Option("Yes", 1), new Option("No"));
        Dialogue dialogue2 = new Dialogue("You forgot you are illiterate");
        tree.dialogues.Add(dialogue1);
        tree.dialogues.Add(dialogue2);
        UserInterface.instance.show(tree);
    }
    public void triggerInteract()
    {
        Debug.Log("Pushed");
    }
}
