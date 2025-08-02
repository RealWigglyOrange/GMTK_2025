using UnityEngine;

public class Bookshelf : MonoBehaviour, IInteractable
{
    public bool bookshelfMoved = false;
    public void interact()
    {
        InteractionTree tree = new InteractionTree();
        Dialogue whatToName = new Dialogue("Do you want to read?", new Option("Yes", 1), new Option("No"));
        Dialogue after = new Dialogue("You can't, you're illiterate");
        tree.dialogues.Add(whatToName);
        tree.dialogues.Add(after);
        UserInterface.instance.show(tree);
    }
    public void triggerInteract()
    {
        bookshelfMoved = true;
        Debug.Log(bookshelfMoved);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
