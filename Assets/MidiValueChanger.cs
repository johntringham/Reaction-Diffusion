using MidiJack;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiValueChanger : MonoBehaviour
{
    public bool DebugPrinting = false;

    public bool ShowAllKnobs = false;
    public bool ShowNotePresses = true;

    public MidiKnobMapping[] Mappings;

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
            Debug.Log("knob num: "+knob+", lenght"+Mappings.Length);

            if (knob-1 < Mappings.Length)
            {
                Debug.Log("???");
                Mappings[knob-1].Update(value);
            }
        }
    }

    void OnNoteOn(MidiChannel channel, int note, float value)
    {
        if (this.ShowNotePresses)
        {
            Debug.Log("Note " + note + " = " + value);
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
        Debug.Log(lerpedValue);

        targetProperty.SetValue(Target, lerpedValue);
    }
}