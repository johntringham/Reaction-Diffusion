
#if UNITY_EDITOR
using UnityEditor;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MidiKnobMapping))]
public class MidiKnobMappingPropertyDrawer : PropertyDrawer
{
    private int choiceIndex = 0;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var indent = EditorGUI.indentLevel;

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        EditorGUI.indentLevel = 0; // ?

        var gridSplitter = new RectGridSplitter(position, "1* 1*", "2* 1* 1*");

        SerializedProperty midiMappingTargetObjectProperty = property.FindPropertyRelative(nameof(MidiKnobMapping.Target));
        EditorGUI.PropertyField(gridSplitter.GetRect(0, 0, 3), midiMappingTargetObjectProperty, GUIContent.none);
        
        var targetProperty = property.FindPropertyRelative("Target");
        var targetValue = targetProperty.objectReferenceValue;
        var valueType = targetValue.GetType();
        System.Reflection.FieldInfo[] fieldInfos = valueType.GetFields();
        var reflectionProperties = fieldInfos.Where(p => p.FieldType.IsAssignableFrom(typeof(float)) && p.DeclaringType == valueType).ToList();

        SerializedProperty midiTargetPropertyNameProperty = property.FindPropertyRelative("PropertyName");
        var currentlySelectedReflectionProperty = reflectionProperties.FirstOrDefault(p => p.Name == midiTargetPropertyNameProperty.stringValue);
        var currentSelectedIndex = reflectionProperties.IndexOf(currentlySelectedReflectionProperty);

        var newIndex = EditorGUI.Popup(gridSplitter.GetRect(0, 1), currentSelectedIndex, reflectionProperties.Select(p => p.Name).ToArray());

        if (newIndex != currentSelectedIndex)
        {
            if (newIndex == -1) {
                midiTargetPropertyNameProperty.stringValue = string.Empty;
            }
            else {
                midiTargetPropertyNameProperty.stringValue = reflectionProperties[newIndex].Name;
            } 
        }

        var rangeProperty = property.FindPropertyRelative(nameof(MidiKnobMapping.Range));
        var rangeMinProperty = rangeProperty.FindPropertyRelative(nameof(Vector2.x));
        var rangeMaxProperty = rangeProperty.FindPropertyRelative(nameof(Vector2.y));
        EditorGUI.PropertyField(gridSplitter.GetRect(1, 1), rangeMinProperty, GUIContent.none);
        EditorGUI.PropertyField(gridSplitter.GetRect(2, 1), rangeMaxProperty, GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }
}

#endif