using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLifeScript : ComputeShaderTextureRendererBase
{
    public override void ResetGrid()
    {
        int kernelHandle = Shader.FindKernel("CSResetGrid");
        Shader.SetInt("RandomOffset", (int)(Time.timeSinceLevelLoad * 100));
        Shader.SetTexture(kernelHandle, "Result", currentTexture);

        Shader.Dispatch(kernelHandle, TexResolution / 8, TexResolution / 8, 1);
        renderer.material.SetTexture("_BaseMap", currentTexture);
    }
}