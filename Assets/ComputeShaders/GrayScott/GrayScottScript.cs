using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class GrayScottScript : MonoBehaviour
{
    struct GrayScottStruct
    {
        float A;
        float B;
    }

    public ComputeShader Shader;
    public int TexResolution = 512;

    protected Renderer renderer;
    protected RenderTexture renderTexture;
    //protected RenderTexture renderTexture2;
    protected int currentBufferIndex = 0;
    //protected RenderTexture currentTexture => currentTextureIndex % 2 == 0 ? renderTexture : renderTexture2;
    //protected RenderTexture previousTexture => currentTextureIndex % 2 == 1 ? renderTexture : renderTexture2;

    public float StartingRadius = 30;

    public float Kill;
    public float Feed;
    public float ADiffusionRate;
    public float BDiffusionRate;
    public float DeltaTime;

    private ComputeBuffer buffer1;
    private ComputeBuffer buffer2;

    private ComputeBuffer CurrentBuffer => currentBufferIndex % 2 == 0 ? buffer1 : buffer2;
    private ComputeBuffer PreviousBuffer => currentBufferIndex % 2 == 1 ? buffer1 : buffer2;

    public void ResetGrid()
    {
        buffer1 = new ComputeBuffer(TexResolution * TexResolution, sizeof(float) * 2);
        var data = Enumerable.Repeat(new GrayScottStruct(), TexResolution * TexResolution).ToArray();
        buffer1.SetData(data);

        buffer2 = new ComputeBuffer(TexResolution * TexResolution, sizeof(float) * 2);
        buffer2.SetData(data);

        int kernelHandle = Shader.FindKernel("CSResetGrid");
        Shader.SetFloat("Radius", StartingRadius);
        Shader.SetInt("TexSize", TexResolution);

        Shader.SetFloat("Kill", this.Kill);
        Shader.SetFloat("Feed", this.Feed);
        Shader.SetFloat("ADiffusionRate", this.ADiffusionRate);
        Shader.SetFloat("BDiffusionRate", this.BDiffusionRate);
        Shader.SetFloat("DeltaTime", this.DeltaTime);

        Shader.SetTexture(kernelHandle, "Bitmap", renderTexture);

        Shader.SetBuffer(kernelHandle, "Current", CurrentBuffer);
        Shader.SetBuffer(kernelHandle, "Prev", PreviousBuffer);

        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);
        
        renderer.material.SetTexture("_BaseMap", renderTexture);
    }

    private void UpdateTextureFromCompute()
    {
        currentBufferIndex++;

        int kernelHandle = Shader.FindKernel("CSMain");

        Shader.SetBuffer(kernelHandle, "Current", CurrentBuffer);
        Shader.SetBuffer(kernelHandle, "Prev", PreviousBuffer);

        Shader.SetFloat("Kill", this.Kill);
        Shader.SetFloat("Feed", this.Feed);
        Shader.SetFloat("ADiffusionRate", this.ADiffusionRate);
        Shader.SetFloat("BDiffusionRate", this.BDiffusionRate);
        Shader.SetFloat("DeltaTime", this.DeltaTime);

        Shader.SetTexture(kernelHandle, "Bitmap", renderTexture);

        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);
        
        renderer.material.SetTexture("_BaseMap", renderTexture);
    }

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

        //this.renderTexture2 = new RenderTexture(TexResolution, TexResolution, 24);
        //this.renderTexture2.enableRandomWrite = true;
        //this.renderTexture2.antiAliasing = 1;
        //this.renderTexture2.filterMode = FilterMode.Point;
        //this.renderTexture.wrapMode = TextureWrapMode.Clamp;
        //this.renderTexture.wrapModeU = TextureWrapMode.Clamp;
        //this.renderTexture.wrapModeV = TextureWrapMode.Clamp;
        //this.renderTexture2.Create();

        this.renderer = GetComponent<Renderer>();
        renderer.enabled = true;

        ResetGrid();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        //{
            UpdateTextureFromCompute();
            UpdateTextureFromCompute();
            UpdateTextureFromCompute();
            UpdateTextureFromCompute();
            UpdateTextureFromCompute();
        //}
    }
}

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