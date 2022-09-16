//using MidiJack;
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

    public PlayerInputActions playerInputActions;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.ActionMap.Midi1.performed += (e) => KnobChanged(1, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi2.performed += (e) => KnobChanged(2, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi3.performed += (e) => KnobChanged(3, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi4.performed += (e) => KnobChanged(4, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi5.performed += (e) => KnobChanged(5, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi6.performed += (e) => KnobChanged(6, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi7.performed += (e) => KnobChanged(7, e.ReadValue<float>());
        playerInputActions.ActionMap.Midi8.performed += (e) => KnobChanged(8, e.ReadValue<float>());
    }

    private void Update()
    {
        //var midi1 = playerInputActions?.ActionMap.Midi1.ReadValue<float>();

        //Debug.Log("i am turning into a demon" + midi1);
    }

    private void OnEnable()
    {
        playerInputActions?.Enable();
    }

    private void OnDisable()
    {
        playerInputActions?.Disable();
    }

    private void KnobChanged(int knob, float value)
    {
        Debug.Log("knob " + knob + " changed to value: " + value);

        if (knob - 1 < KnobMappings.Length)
        {
            KnobMappings[knob - 1].Update(value);
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    var knobNumbers = MidiMaster.GetKnobNumbers();
    //    foreach (var knob in knobNumbers)
    //    {
    //        var value = MidiMaster.GetKnob(knob);

    //        if (knob-1 < KnobMappings.Length)
    //        {
    //            KnobMappings[knob-1].Update(value);
    //        }
    //    }
    //}

    //void OnNoteOn(MidiChannel channel, int note, float value)
    //{
    //    if (this.ShowNotePresses)
    //    {
    //        Debug.Log("Note " + note + " = " + value);
    //    }

    //    var mapping = this.ButtonMappings.FirstOrDefault(b => b.NoteNumber == note);
    //    if(mapping != null)
    //    {
    //        mapping.Execute();
    //    }
    //}

    //void OnKnob(MidiChannel channel, int note, float value)
    //{
    //    if (this.ShowAllKnobs)
    //    {
    //        Debug.Log("Knob " + note + " = " + value);
    //    }
    //}
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