using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionTree
{
    public List<Dialogue> dialogues;
}

public class Option
{
    public string text;
    public GameObject script;

    public Option(string text, GameObject script)
    {
        this.text = text;
        this.script = script;
    }

    public Option(string text)
    {
        this.text = text;
    }
}

[Serializable]
public class Dialogue
{
    public string text;
    public List<Option> options;

    public int nextIndex;

    public Dialogue(string text, params Option[] options)
    {
        this.text = text;
        this.options = options.ToList();
    }
}