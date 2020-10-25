using MidiJack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MidiValueChanger : MonoBehaviour
{
    public bool DebugPrinting = false;

    public bool ShowAllKnobs = false;
    public bool ShowNotePresses = true;

    public MidiKnobMapping[] KnobMappings;
    public MidiButtonMapping[] ButtonMappings;

    // Start is called before the first frame update
    void Start()
    {
        MidiMaster.noteOnDelegate = new MidiDriver.NoteOnDelegate(this.OnNoteOn);
    }

    // Update is called once per frame
    void Update()
    {
        var knobNumbers = MidiMaster.GetKnobNumbers();
        foreach (var knob in knobNumbers)
        {
            var value = MidiMaster.GetKnob(knob);

            if (knob-1 < KnobMappings.Length)
            {
                KnobMappings[knob-1].Update(value);
            }
        }
    }

    void OnNoteOn(MidiChannel channel, int note, float value)
    {
        if (this.ShowNotePresses)
        {
            Debug.Log("Note " + note + " = " + value);
        }

        var mapping = this.ButtonMappings.FirstOrDefault(b => b.NoteNumber == note);
        if(mapping != null)
        {
            mapping.Execute();
        }
    }

    void OnKnob(MidiChannel channel, int note, float value)
    {
        if (this.ShowAllKnobs)
        {
            Debug.Log("Knob " + note + " = " + value);
        }
    }
}

[Serializable]
public class MidiKnobMapping
{
    public MonoBehaviour Target;

    public string PropertyName;
    public Vector2 Range;

    public void Update(float value)
    {
        var targetType = Target.GetType();
        var targetProperty = targetType.GetField(PropertyName);
        var lerpedValue = Mathf.Lerp(this.Range.x, this.Range.y, value);
        
        targetProperty.SetValue(Target, lerpedValue);
    }
}

[Serializable]
public class MidiButtonMapping
{
    public MonoBehaviour Target;

    public string MethodName;

    public int NoteNumber;

    public void Execute()
    {
        var targetType = Target.GetType();
        var targetMethod = targetType.GetMethod(MethodName);

        targetMethod.Invoke(Target, new object[] { });
    }
}