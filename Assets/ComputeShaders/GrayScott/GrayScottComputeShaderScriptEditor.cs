using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
[CustomEditor(typeof(GrayScottScript))]
public class GrayScottComputeShaderScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var computeShaderScript = (GrayScottScript)target;
        if (GUILayout.Button("Reset"))
        {
            computeShaderScript.ResetGrid();
        }
    }
}
#endif