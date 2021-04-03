using System;
using UnityEngine;
using UnityEngine.UIElements;

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
