using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class SlimeMoldScript : MonoBehaviour
{
    struct SlimeMoldAgent
    {
        public float2 position;
        public float angle;
    }

    public struct float2
    {
        public float x;
        public float y;
    }

    public ComputeShader SlimeMoldShader;

    public int TexResolution = 512;

    public int NumberOfAgents = 100;

    public Material targetMaterial;

    public Texture2D fadeMask;

    protected RenderTexture renderTexture;
    protected int currentBufferIndex = 0;

    private ComputeBuffer agentsBuffer;

    public float SensorDistance;
    public float SensorAngle;
    public float Speed;
    public float TurningPower;

    public float TrailBlurSpeed;
    public float TrailFadeSpeed;

    void Start()
    {
        this.renderTexture = new RenderTexture(TexResolution, TexResolution, 24);
        this.renderTexture.enableRandomWrite = true;
        this.renderTexture.antiAliasing = 1;
        this.renderTexture.filterMode = FilterMode.Bilinear;
        this.renderTexture.wrapMode = TextureWrapMode.Clamp;
        this.renderTexture.wrapModeU = TextureWrapMode.Clamp;
        this.renderTexture.wrapModeV = TextureWrapMode.Clamp;
        this.renderTexture.Create();

        ResetGrid();
    }

    void Update()
    {
        UpdateTextureFromCompute();
        //UpdateTextureFromCompute();
        //UpdateTextureFromCompute();
        //UpdateTextureFromCompute();
    }

    public void ResetGrid()
    {
        ResetGridAndRunKernel("ResetGrid");
    }

    public void ResetGridAndRunKernel(string kernel)
    {
        agentsBuffer = new ComputeBuffer(this.NumberOfAgents, Marshal.SizeOf(new SlimeMoldAgent()));
        var data = GetInitialSlimeMouldAgents(this.NumberOfAgents).ToArray();
        agentsBuffer.SetData(data);

        SetShaderValues();

        int kernelHandle = SlimeMoldShader.FindKernel(kernel);
        SlimeMoldShader.SetTexture(kernelHandle, "Bitmap", renderTexture);

        SlimeMoldShader.SetBuffer(kernelHandle, "Agents", this.agentsBuffer);
        SlimeMoldShader.Dispatch(kernelHandle, NumberOfAgents / 16, 1, 1);
        targetMaterial.SetTexture("_BaseMap", renderTexture);
    }

    private void SetShaderValues()
    {
        SlimeMoldShader.SetFloat("SensorDistance", this.SensorDistance);
        SlimeMoldShader.SetFloat("SensorAngle", this.SensorAngle);
        SlimeMoldShader.SetFloat("Speed", this.Speed);
        SlimeMoldShader.SetFloat("TrailFadeSpeed", this.TrailFadeSpeed);
        SlimeMoldShader.SetFloat("TrailBlurSpeed", this.TrailBlurSpeed);

        SlimeMoldShader.SetFloat("DeltaTime", Time.fixedDeltaTime);
        SlimeMoldShader.SetFloat("TurningPower", this.TurningPower);

        SlimeMoldShader.SetInt("TexSize", TexResolution);
        SlimeMoldShader.SetInt("NumberOfAgents", this.NumberOfAgents);
    }

    private void UpdateTextureFromCompute()
    {
        int updateKernelHandle = SlimeMoldShader.FindKernel("Update");

        SlimeMoldShader.SetBuffer(updateKernelHandle, "Agents", this.agentsBuffer);

        SetShaderValues();

        SlimeMoldShader.SetTexture(updateKernelHandle, "Bitmap", renderTexture);
        SlimeMoldShader.Dispatch(updateKernelHandle, NumberOfAgents / 16, 1, 1);

        int blurKernelHandle = SlimeMoldShader.FindKernel("Blur");

        SlimeMoldShader.SetTexture(blurKernelHandle, "Bitmap", renderTexture);
        SlimeMoldShader.Dispatch(blurKernelHandle, TexResolution / 8, TexResolution / 8, 1);

        targetMaterial.SetTexture("_BaseMap", renderTexture);
    }

    private IEnumerable<SlimeMoldAgent> GetInitialSlimeMouldAgents(int number)
    {
        for (int i = 0; i < number; i++)
        {
            yield return new SlimeMoldAgent()
            {
                position = new float2()
                {
                    x = UnityEngine.Random.Range(0f, TexResolution),
                    y = UnityEngine.Random.Range(0f, TexResolution),
                },
                angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f),
            };
        }
    }
}
