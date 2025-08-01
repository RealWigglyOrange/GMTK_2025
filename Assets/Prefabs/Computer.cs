using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public InteractionTree interactionTree;
    public GameObject option3;
    public void interact()
    {
        UserInterface.instance.show(interactionTree);
    }
    void Start()
    {
        interactionTree = new InteractionTree();
        interactionTree.dialogues = new List<Dialogue>();
        Dialogue dialogue1 = new Dialogue();
        dialogue1.type = DialogueType.NoOptions;
        dialogue1.text = "This is text";
        dialogue1.nextIndex = 1;

        Dialogue dialogue2 = new Dialogue();
        dialogue2.type = DialogueType.NoOptions;
        dialogue2.text = "This is the next text";
        dialogue2.nextIndex = 2;

        Dialogue dialogue3 = new Dialogue();
        dialogue3.type = DialogueType.ThreeOptions;
        dialogue3.text = "This is text with options";
        dialogue3.optionOneText = "Red Pill";
        dialogue3.optionTwoText = "Blue Pill";
        dialogue3.optionThreeText = "Back";
        dialogue3.optionThreeScript = option3;
        dialogue3.nextIndex = -1;

        interactionTree.dialogues.Add(dialogue1);
        interactionTree.dialogues.Add(dialogue2);
        interactionTree.dialogues.Add(dialogue3);
    }

}
