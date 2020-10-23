using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public abstract class ComputeShaderTextureRendererBase : MonoBehaviour
{
    public ComputeShader Shader;
    public int TexResolution = 512;

    protected Renderer renderer;
    protected RenderTexture renderTexture;
    protected RenderTexture renderTexture2;
    protected int currentTextureIndex = 0;
    protected RenderTexture currentTexture => currentTextureIndex % 2 == 0 ? renderTexture : renderTexture2;
    protected RenderTexture previousTexture => currentTextureIndex % 2 == 1 ? renderTexture : renderTexture2;

    // Start is called before the first frame update
    void Start()
    {
        this.renderTexture = new RenderTexture(TexResolution, TexResolution, 24);
        this.renderTexture.enableRandomWrite = true;
        this.renderTexture.antiAliasing = 1;
        this.renderTexture.filterMode = FilterMode.Point;
        this.renderTexture.wrapMode = TextureWrapMode.Clamp;
        this.renderTexture.wrapModeU = TextureWrapMode.Clamp;
        this.renderTexture.wrapModeV = TextureWrapMode.Clamp;
        this.renderTexture.Create();

        this.renderTexture2 = new RenderTexture(TexResolution, TexResolution, 24);
        this.renderTexture2.enableRandomWrite = true;
        this.renderTexture2.antiAliasing = 1;
        this.renderTexture2.filterMode = FilterMode.Point;
        this.renderTexture.wrapMode = TextureWrapMode.Clamp;
        this.renderTexture.wrapModeU = TextureWrapMode.Clamp;
        this.renderTexture.wrapModeV = TextureWrapMode.Clamp;
        this.renderTexture2.Create();

        this.renderer = GetComponent<Renderer>();
        renderer.enabled = true;

        ResetGrid();

        UpdateTextureFromCompute();
    }

    public abstract void ResetGrid();

    private void UpdateTextureFromCompute()
    {
        currentTextureIndex++;

        int kernelHandle = Shader.FindKernel("CSMain");

        Shader.SetTexture(kernelHandle, "Prev", previousTexture);
        Shader.SetTexture(kernelHandle, "Result", currentTexture);

        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);
        renderer.material.SetTexture("_BaseMap", currentTexture);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            UpdateTextureFromCompute();
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(ComputeShaderTextureRendererBase))]
public class ComputeShaderScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var computeShaderScript = (ComputeShaderTextureRendererBase)target;
        if (GUILayout.Button("Reset"))
        {
            computeShaderScript.ResetGrid();
        }
    }
}
#endif
