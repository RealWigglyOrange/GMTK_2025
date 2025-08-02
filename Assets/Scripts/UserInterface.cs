using System;
using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameMode GM;

    public static UserInterface instance;
    public GameObject canvas;
    public GameObject panel;
    public GameObject fastForward;
    public TextMeshProUGUI timeText;
    public GameObject options;
    public TextMeshProUGUI optionOneText;
    public TextMeshProUGUI optionTwoText;
    public TextMeshProUGUI optionThreeText;
    public GameObject optionOneIndicator;
    public GameObject optionTwoIndicator;
    public GameObject optionThreeIndicator;
    public PlayerController player;
    public TextMeshProUGUI uiText;
    InteractionTree activeInteractionTree;
    public int currentInteractionIndex = 0;
    int optionSelectionIndex = 0;
    int optionAmount = 0;

    public void Awake()
    {
        instance = this;
        panel.SetActive(false);
        fastForward.SetActive(false);
        options.SetActive(false);
    }

    void Update()
    {
        updateClock();
        fastForward.SetActive(player.fastForwarding);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            optionSelectionIndex--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            optionSelectionIndex++;
        }

        updateOptions();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Dialogue dialogue = activeInteractionTree.dialogues[currentInteractionIndex];
            if (dialogue.type == DialogueType.ThreeOptions || dialogue.type == DialogueType.TwoOptions)
            {
                switch (optionSelectionIndex)
                {
                    case 0:
                        if (dialogue.optionOneScript)
                        dialogue.optionOneScript.GetComponent<IOption>().execute();
                        break;
                    case 1:
                        if (dialogue.optionTwoScript)
                        dialogue.optionTwoScript.GetComponent<IOption>().execute();
                        break;
                    case 2:
                        if (dialogue.optionThreeScript)
                        dialogue.optionThreeScript.GetComponent<IOption>().execute();
                        break;
                }
            }

            nextDialogue();
        }
    }

    public void nextDialogue()
    {
        int nextIndex = activeInteractionTree.dialogues[currentInteractionIndex].nextIndex;
        if (nextIndex == -1)
        {
            exitInteraction();
            return;
        }
        currentInteractionIndex = activeInteractionTree.dialogues[currentInteractionIndex].nextIndex;
        Dialogue dialogue = activeInteractionTree.dialogues[currentInteractionIndex];

        displayDialogue(dialogue);

    }

    void displayDialogue(Dialogue dialogue)
    {
        switch (dialogue.type)
        {
            case DialogueType.NoOptions:
                uiText.text = dialogue.text;
                optionAmount = 0;
                break;
            case DialogueType.ThreeOptions:
                showOptions();
                optionOneText.text = dialogue.optionOneText;
                optionTwoText.text = dialogue.optionTwoText;
                optionThreeText.text = dialogue.optionThreeText;
                optionAmount = 3;
                break;
        }
    }

    public void perviousDialogue()
    {
        currentInteractionIndex--;
        Dialogue dialogue = activeInteractionTree.dialogues[currentInteractionIndex];
        displayDialogue(dialogue);
    }

    public void updateOptions()
    {
        if (optionSelectionIndex > optionAmount || optionSelectionIndex < 0)
        {
            optionSelectionIndex = optionAmount;
        }

        if (optionAmount == 0)
        {
            hideOptions();
            return;
        }
        switch (optionSelectionIndex)
        {
            case 0:
                optionOneIndicator.SetActive(true);
                optionTwoIndicator.SetActive(false);
                optionThreeIndicator.SetActive(false);
                break;
            case 1:
                optionOneIndicator.SetActive(false);
                optionTwoIndicator.SetActive(true);
                optionThreeIndicator.SetActive(false);
                break;
            case 2:
                optionOneIndicator.SetActive(false);
                optionTwoIndicator.SetActive(false);
                optionThreeIndicator.SetActive(true);
                break;
        }
    }

    public void exitInteraction()
    {
        hide();
        hideOptions();
        player.interacting = false;
        currentInteractionIndex = 0;
    }

    public void show(InteractionTree interactionTree)
    {
        player.interacting = true;
        panel.SetActive(true);
        uiText.text = interactionTree.dialogues[0].text;
        activeInteractionTree = interactionTree;
    }

    public void showOptions()
    {
        options.SetActive(true);
    }

    public void hideOptions()
    {
        options.SetActive(false);
    }

    public void hide()
    {
        panel.SetActive(false);
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
