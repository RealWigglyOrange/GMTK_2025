using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;

    [SerializeField] GameMode GM;
    [SerializeField] PlayerController player;

    [Header("UI Assets")]
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] TextMeshProUGUI[] optionsText;
    [SerializeField] GameObject[] optionIndicators;
    [SerializeField] GameObject fastForward;
    [SerializeField] TextMeshProUGUI timeText;

    InteractionTree activeInteractionTree;
    [NonSerialized]
    int currentInteractionIndex = 0;
    int optionSelectionIndex = 0;
    int optionAmount = 0;
    IEnumerator<Dialogue> enumerator;

    public void Awake()
    {
        instance = this;
        dialoguePanel.SetActive(false);
        fastForward.SetActive(false);
        optionsPanel.SetActive(false);
    }

    void Update()
    {
        updateClock();
        fastForward.SetActive(player.fastForwarding);

        optionSelection();

        updateOptions();

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Debug.Log($"Before: {currentInteractionIndex}");

            Dialogue dialogue = activeInteractionTree.dialogues[currentInteractionIndex];
            if (dialogue.options.Count != 0)
            {
                dialogue.options[optionSelectionIndex].script?.GetComponent<IOption>().execute();
            }

            displayDialogue(dialogue);

            //If there are more dialogues
            if (enumerator.MoveNext())
            {
                //Clamp from 0 to max dialogue amount (minus one for array)
                //Sorry y'all, I couldn't find a better fix than this crappy hack ;-;
                currentInteractionIndex = (currentInteractionIndex + 1) % activeInteractionTree.dialogues.Count;
                // Debug.Log(currentInteractionIndex);
            }
            else
            {
                exitInteraction();
                return;
            }

            // Debug.Log($"After: {currentInteractionIndex}");
        }
    }

    private IEnumerable<Dialogue> getNextDialogue(InteractionTree tree)
    {
        foreach (Dialogue dialogue in tree.dialogues)
        {
            // Debug.Log($"Fired");
            yield return dialogue;
        }
    }

    public void nextDialogue()
    {
        if (enumerator.MoveNext())
        {
            currentInteractionIndex++;
            displayDialogue(enumerator.Current);
        }
        else
        {
            exitInteraction();
            return;
        }

    }

    void displayDialogue(Dialogue dialogue)
    {
        optionAmount = dialogue.options.Count;
        switch (optionAmount)
        {
            case 0:
                dialogueText.text = dialogue.text;
                break;
            case 3:
                showOptions();
                optionsText[0].text = dialogue.options[0].text;
                optionsText[1].text = dialogue.options[1].text;
                optionsText[2].text = dialogue.options[2].text;
                break;
        }
    }

    public void previousDialogue()
    {
        displayDialogue(activeInteractionTree.dialogues[--currentInteractionIndex]);
    }

    void optionSelection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (optionAmount != 0)
                optionSelectionIndex = optionSelectionIndex - 1;
            if (optionSelectionIndex < 0)
                optionSelectionIndex = optionAmount-1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (optionAmount != 0)
                optionSelectionIndex = (optionSelectionIndex + 1) % optionAmount;
        }
    }

    public void updateOptions()
    {
        if (optionAmount == 0)
        {
            hideOptions();
            return;
        }
        switch (optionSelectionIndex)
        {
            case 0:
                optionIndicators[0].SetActive(true);
                optionIndicators[1].SetActive(false);
                optionIndicators[2].SetActive(false);
                break;
            case 1:
                optionIndicators[0].SetActive(false);
                optionIndicators[1].SetActive(true);
                optionIndicators[2].SetActive(false);
                break;
            case 2:
                optionIndicators[0].SetActive(false);
                optionIndicators[1].SetActive(false);
                optionIndicators[2].SetActive(true);
                break;
        }
    }

    public void exitInteraction()
    {
        hidePanel();
        hideOptions();
        player.interacting = false;
        currentInteractionIndex = 0;
    }

    public void show(InteractionTree interactionTree)
    {
        player.interacting = true;
        dialoguePanel.SetActive(true);
        dialogueText.text = interactionTree.dialogues[0].text;
        activeInteractionTree = interactionTree;
        enumerator = getNextDialogue(activeInteractionTree).GetEnumerator();
    }

    public void showOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void hideOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void hidePanel()
    {
        dialoguePanel.SetActive(false);
    }

    void updateClock()
    {
        float hours = Mathf.Floor(GM.minutes / 60) + 9.0f;
        float minutes = GM.minutes % 60;

        if (GM.minutes < 10)
        {
            timeText.text = hours + ":0" + minutes;
        }
        else
        {
            timeText.text = hours + ":" + minutes;
        }
    }
}
