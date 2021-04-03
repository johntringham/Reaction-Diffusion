using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GrayScottScript : MonoBehaviour
{
    struct GrayScottStruct
    {
        float A;
        float B;
    }

    public Vector3[] BaseLaplacianMatrix;

    public ComputeShader Shader;
    public int TexResolution = 512;

    public Material targetMaterial;

    protected RenderTexture renderTexture;
    protected int currentBufferIndex = 0;

    public float StartingRadius = 30;

    public float Kill;
    public float Feed;
    public float ADiffusionRate;
    public float BDiffusionRate;
    public float DeltaTime;

    public float YLaplaceShift = 0;
    public float XLaplaceShift = 0;

    private ComputeBuffer buffer1;
    private ComputeBuffer buffer2;

    private ComputeBuffer CurrentBuffer => currentBufferIndex % 2 == 0 ? buffer1 : buffer2;
    private ComputeBuffer PreviousBuffer => currentBufferIndex % 2 == 1 ? buffer1 : buffer2;

    public void ResetGridAndRunKernel(string kernel)
    {
        buffer1 = new ComputeBuffer(TexResolution * TexResolution, sizeof(float) * 2);
        var data = Enumerable.Repeat(new GrayScottStruct(), TexResolution * TexResolution).ToArray();
        buffer1.SetData(data);

        buffer2 = new ComputeBuffer(TexResolution * TexResolution, sizeof(float) * 2);
        buffer2.SetData(data);

        Shader.SetFloat("Radius", StartingRadius);
        Shader.SetInt("TexSize", TexResolution);

        SetShaderValues();

        int kernelHandle = Shader.FindKernel(kernel);
        Shader.SetTexture(kernelHandle, "Bitmap", renderTexture);

        Shader.SetBuffer(kernelHandle, "Current", CurrentBuffer);
        Shader.SetBuffer(kernelHandle, "Prev", PreviousBuffer);

        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);

        targetMaterial.SetTexture("_BaseMap", renderTexture);
    }

    private void SetShaderValues()
    {
        Shader.SetFloat("Kill", this.Kill);
        Shader.SetFloat("Feed", this.Feed);
        Shader.SetFloat("ADiffusionRate", this.ADiffusionRate);
        Shader.SetFloat("BDiffusionRate", this.BDiffusionRate);
        Shader.SetFloat("DeltaTime", this.DeltaTime);

        //float[] laplace = this.LaplacianMatrix.SelectMany(v => new[] { 
        //    v.x, v.x, v.x, v.x, 
        //    v.y, v.y, v.y, v.y,
        //    v.z, v.z, v.z, v.z
        //}).ToArray();

        // squaring so that values close to zero become very close to zero (mine doesn't make it easy to zero it and these values are sensitive)
        var xShift = this.XLaplaceShift * Mathf.Abs(this.XLaplaceShift);
        var yShift = this.YLaplaceShift * Mathf.Abs(this.YLaplaceShift);

        Shader.SetFloats("laplacianR1", this.BaseLaplacianMatrix[0].x, this.BaseLaplacianMatrix[0].y + xShift, this.BaseLaplacianMatrix[0].z);
        Shader.SetFloats("laplacianR2", this.BaseLaplacianMatrix[1].x - yShift, this.BaseLaplacianMatrix[1].y, this.BaseLaplacianMatrix[1].z + yShift);
        Shader.SetFloats("laplacianR3", this.BaseLaplacianMatrix[2].x, this.BaseLaplacianMatrix[2].y - xShift, this.BaseLaplacianMatrix[2].z);

        //Shader.SetFloats("laplacian", laplace);
    }

    public void ResetGrid()
    {
        ResetGridAndRunKernel("CSResetGrid");
    }

    public void ResetGridToCircle()
    {
        ResetGridAndRunKernel("CSResetGridToCircle");
    }

    private void UpdateTextureFromCompute()
    {
        currentBufferIndex++;

        int kernelHandle = Shader.FindKernel("CSMain");

        Shader.SetBuffer(kernelHandle, "Current", CurrentBuffer);
        Shader.SetBuffer(kernelHandle, "Prev", PreviousBuffer);

        SetShaderValues();

        Shader.SetTexture(kernelHandle, "Bitmap", renderTexture);
        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);
        
        targetMaterial.SetTexture("_BaseMap", renderTexture);
    }

    // Start is called before the first frame update
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
        UpdateTextureFromCompute();
        UpdateTextureFromCompute();
        UpdateTextureFromCompute();
    }
}

#if UNITY_EDITOR
#endif