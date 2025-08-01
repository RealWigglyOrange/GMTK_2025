using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTree
{
    public List<Dialogue> dialogues;
}

public enum DialogueType
{
    NoOptions, TwoOptions, ThreeOptions
}

[Serializable]
public class Dialogue
{
    [field: SerializeField] public DialogueType type;
    [field: SerializeField] public string text;
    [field: SerializeField] public string optionOneText;
    [field: SerializeField] public GameObject optionOneScript;
    [field: SerializeField] public string optionTwoText;
    [field: SerializeField] public GameObject optionTwoScript;
    [field: SerializeField] public string optionThreeText;
    [field: SerializeField] public GameObject optionThreeScript;

    [field: SerializeField] public int nextIndex;
}