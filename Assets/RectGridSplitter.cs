using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
