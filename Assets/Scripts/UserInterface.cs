using System;
using System.Collections.Generic;
using System.Linq;
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
    [NonSerialized]
    public int currentInteractionIndex = 0;
    int optionSelectionIndex = 0;
    int optionAmount = 0;
    IEnumerator<Dialogue> enumerator;

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
            if (optionAmount != 0)
                optionSelectionIndex = optionSelectionIndex - 1;
            if (optionSelectionIndex < 0)
                optionSelectionIndex = optionAmount-1;
            Debug.Log(optionAmount);
            Debug.Log("selection index: " + optionSelectionIndex);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (optionAmount != 0)
                optionSelectionIndex = (optionSelectionIndex + 1) % optionAmount;
            Debug.Log(optionAmount);
            Debug.Log("selection index: " + optionSelectionIndex);
        }

        updateOptions();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log($"Before: {currentInteractionIndex}");

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
                Debug.Log(currentInteractionIndex);
            }
            else
            {
                exitInteraction();
                return;
            }

            Debug.Log($"After: {currentInteractionIndex}");
        }
    }

    private IEnumerable<Dialogue> getNextDialogue(InteractionTree tree)
    {
        foreach (Dialogue dialogue in tree.dialogues)
        {
            Debug.Log($"Fired");
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
                uiText.text = dialogue.text;
                break;
            case 3:
                showOptions();
                optionOneText.text = dialogue.options[0].text;
                optionTwoText.text = dialogue.options[1].text;
                optionThreeText.text = dialogue.options[2].text;
                break;
        }
    }

    public void previousDialogue()
    {
        displayDialogue(activeInteractionTree.dialogues[--currentInteractionIndex]);
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
        hidePanel();
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
        enumerator = getNextDialogue(activeInteractionTree).GetEnumerator();
    }

    public void showOptions()
    {
        options.SetActive(true);
    }

    public void hideOptions()
    {
        options.SetActive(false);
    }

    public void hidePanel()
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
