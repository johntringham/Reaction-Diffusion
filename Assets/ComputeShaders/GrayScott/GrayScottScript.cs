using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

public class GrayScottScript : ComputeShaderTextureRendererBase
{
    public float StartingRadius = 30;

    public float Kill;
    public float Feed;
    public float ADiffusionRate;
    public float BDiffusionRate;
    public float DeltaTime;

    public override void ResetGrid()
    {
        int kernelHandle = Shader.FindKernel("CSResetGrid");
        Shader.SetFloat("Radius", StartingRadius);
        Shader.SetInt("TexSize", TexResolution);

        Shader.SetFloat("Kill", this.Kill);
        Shader.SetFloat("Feed", this.Feed);
        Shader.SetFloat("ADiffusionRate", this.ADiffusionRate);
        Shader.SetFloat("BDiffusionRate", this.BDiffusionRate);
        Shader.SetFloat("DeltaTime", this.DeltaTime);

        Shader.SetTexture(kernelHandle, "Result", currentTexture);

        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);
        renderer.material.SetTexture("_BaseMap", currentTexture);
    }
}

[CustomEditor(typeof(GrayScottScript))]
public class GrayScottComputeShaderScriptEditor : ComputeShaderScriptEditor { }