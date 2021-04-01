using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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

public class RectGridSplitter
{
    private struct GridLength
    {
        public float Length;
        public bool Star;
    }

    private List<GridLength> RowGridLengths;
    private List<GridLength> ColumnGridLengths;

    public Rect initialRect;

    private Rect[,] rectArray;

    private float margin = 2;

    public RectGridSplitter(Rect input, int numberOfRows, int numberOfColumns)
        : this(input, string.Join("", Enumerable.Repeat("1* ", numberOfRows)), string.Join("", Enumerable.Repeat("1* ", numberOfColumns)))
    {
    }

    public RectGridSplitter(Rect input, string rowSplitString = "1*", string columnSplitString = "1*")
    {
        this.RowGridLengths = StringToGridLengthsList(rowSplitString);
        this.ColumnGridLengths = StringToGridLengthsList(columnSplitString);

        this.initialRect = input;

        this.rectArray = new Rect[ColumnGridLengths.Count, RowGridLengths.Count];

        // columns first:
        var totalAbsoluteWidths = this.ColumnGridLengths.Where(r => !r.Star).Aggregate(0f, (total, gl) => total + gl.Length);
        var totalStarWidths = this.ColumnGridLengths.Where(r => r.Star).Aggregate(0f, (total, gl) => total + gl.Length);
        var totalInitalWidth = initialRect.width;

        var marginWidths = (this.ColumnGridLengths.Count - 1) * margin;
        var oneStarWidth = (totalInitalWidth - totalAbsoluteWidths - marginWidths) / totalStarWidths;

        // rows
        var totalAbsoluteHeights = this.RowGridLengths.Where(r => !r.Star).Aggregate(0f, (total, gl) => total + gl.Length);
        var totalStarHeights = this.RowGridLengths.Where(r => r.Star).Aggregate(0f, (total, gl) => total + gl.Length);
        var totalInitalHeight = initialRect.height;

        var marginHeights = (this.RowGridLengths.Count - 1) * margin;
        var oneStarHeight = (totalInitalHeight - totalAbsoluteHeights - marginHeights) / totalStarHeights;

        var xPos = input.x + margin;
        var yPos = input.y + margin;
        
        for (int y = 0; y < RowGridLengths.Count; y++)
        {
            var rowDef = RowGridLengths[y];
            float height = rowDef.Star ? rowDef.Length * oneStarHeight : rowDef.Length;

            for (int x = 0; x < ColumnGridLengths.Count; x++)
            {
                var columnDef = ColumnGridLengths[x];
                float width = columnDef.Star ? columnDef.Length * oneStarWidth : columnDef.Length;
                rectArray[x, y] = new Rect(xPos, yPos, width, height);

                xPos += width + margin;
            }

            xPos = input.x;
            yPos += height + margin;
        }
    }

    public Rect GetRect(int columnIndex, int rowIndex, int columnSpan = 1, int rowSpan = 1)
    {
        if (columnSpan == 1 && rowSpan == 1)
        {
            return rectArray[columnIndex, rowIndex];
        }

        List<Rect> rectCollection = new List<Rect>();

        // this double loop is a bit pointless because really we only need the top left rectangle and the bottom right
        // rectange, we don't need to loop through all of them in order to calculate the max, we already know which rects are
        // those ones. this implementation is dumb but i don't really know why i'm spending so much time here anyway, so i probably won't 
        // rewrite it.
        for (int x = columnIndex; x < columnIndex + columnSpan; x++)
        {
            for (int y = rowIndex; y < rowIndex + rowSpan; y++)
            {
                rectCollection.Add(rectArray[x, y]);
            }
        }

        float xMin = rectCollection.Min(r => r.xMin);
        float xMax = rectCollection.Max(r => r.xMax);
        float yMin = rectCollection.Min(r => r.yMin);
        float yMax = rectCollection.Max(r => r.yMax);

        return new Rect(xMin, yMin, xMax - xMin, yMax - yMin);
    }

    private List<GridLength> StringToGridLengthsList (string input)
    {
        var sanitizedInput = input.Replace(",", " ").Replace("  ", " ").Split(' ');
        var output = sanitizedInput.Select(s => StringToGridLength(s)).ToList();
        return output;
    }

    private GridLength StringToGridLength(string input)
    {
        input = input.Trim();

        bool star = false;
        if (input.EndsWith("*"))
        {
            star = true;
            input = input.Remove(input.Length - 1, 1); // i think that's right
        }

        var value = float.Parse(input);
        return new GridLength() { Length = value, Star = star, };
    }
}
