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
    public int? nextIndex;
    public GameObject script;

    public Option(string text, int nextIndex)
    {
        this.text = text;
        this.nextIndex = nextIndex;
    }

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

    public Dialogue(string text, int nextIndex, params Option[] options)
    {
        this.text = text;
        this.nextIndex = nextIndex;
        this.options = options.ToList();
    }
}