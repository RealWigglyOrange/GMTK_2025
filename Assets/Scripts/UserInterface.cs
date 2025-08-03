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
    int currentInteractionIndex = -1;
    int optionSelectionIndex = 0;
    int optionAmount = 0;

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

        updateDialogue();
    }

    void updateDialogue()
    {
        Dialogue dialogue = null;
        if (activeInteractionTree != null)
        {
            if (currentInteractionIndex == -1)
            {
                dialogue = activeInteractionTree.dialogues[0];
            }
            else
            {
                dialogue = activeInteractionTree.dialogues[currentInteractionIndex];
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (dialogue.options.Count != 0)
                {
                    // just in case bounds checking
                    if (optionSelectionIndex >= dialogue.options.Count || optionSelectionIndex < 0)
                    {
                        optionSelectionIndex = 0;
                    }
                    if (currentInteractionIndex != -1)
                    {
                        // Debug.Log(optionSelectionIndex);
                        dialogue.options[optionSelectionIndex].script?.GetComponent<IOption>().execute();
                    }
                    if (dialogue.options[optionSelectionIndex].nextIndex != null && currentInteractionIndex != -1)
                    {
                        int next = (int)dialogue.options[optionSelectionIndex].nextIndex;
                        if (next == -1)
                        {
                            exitInteraction();
                        }
                        else
                        {
                        currentInteractionIndex = next;
                        }
                    }
                    else
                    {
                        nextDialogue(dialogue);
                    }

                }
                else
                {
                    nextDialogue(dialogue);
                }
            }
        }
        displayDialogue(dialogue);
    }

    void nextDialogue(Dialogue dialogue)
    {

        if (currentInteractionIndex != -1)
        {
            currentInteractionIndex = dialogue.nextIndex;
        }
        else
        {
            currentInteractionIndex = 0;
            return;
        }
        if (dialogue.nextIndex == -1)
        {
            exitInteraction();
        }
    }

    void displayDialogue(Dialogue dialogue)
    {
        if (dialogue != null)
        {
            optionAmount = dialogue.options.Count;
            switch (optionAmount)
            {
                case 0:
                    dialogueText.text = dialogue.text;
                    dialoguePanel.SetActive(true);
                    hideOptions();
                    break;
                case 1:
                    dialogueText.text = dialogue.text;
                    dialoguePanel.SetActive(true);
                    showOptions();
                    optionsText[0].text = dialogue.options[0].text;
                    optionsText[1].text = "";
                    optionsText[2].text = "";
                    break;
                case 2:
                    dialogueText.text = dialogue.text;
                    dialoguePanel.SetActive(true);
                    showOptions();
                    optionsText[0].text = dialogue.options[0].text;
                    optionsText[1].text = dialogue.options[1].text;
                    optionsText[2].text = "";
                    break;
                case 3:
                    dialogueText.text = dialogue.text;
                    dialoguePanel.SetActive(true);
                    showOptions();
                    optionsText[0].text = dialogue.options[0].text;
                    optionsText[1].text = dialogue.options[1].text;
                    optionsText[2].text = dialogue.options[2].text;
                    break;
            }
        }
        else
        {
            hidePanel();
            hideOptions();
        }
    }

    // public void previousDialogue()
    // {
    //     displayDialogue(activeInteractionTree.dialogues[--currentInteractionIndex]);
    // }

    void optionSelection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (optionAmount != 0)
                optionSelectionIndex = optionSelectionIndex - 1;
            if (optionSelectionIndex < 0)
                optionSelectionIndex = optionAmount-1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
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
        optionIndicators[0].SetActive(false);
        optionIndicators[1].SetActive(false);
        optionIndicators[2].SetActive(false);
        optionIndicators[optionSelectionIndex].SetActive(true);
    }

    public void exitInteraction()
    {
        hidePanel();
        hideOptions();
        player.interacting = false;
        currentInteractionIndex = -1;
        optionSelectionIndex = 0;
        activeInteractionTree = null;
        optionAmount = 0;
    }

    public void show(InteractionTree interactionTree)
    {
        player.interacting = true;
        // dialoguePanel.SetActive(true);
        activeInteractionTree = interactionTree;
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
