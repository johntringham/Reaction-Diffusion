using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleReplaceTexture : MonoBehaviour
{
    public ComputeShader Shader;
    public int TexResolution;

    private Renderer renderer;
    private RenderTexture renderTexture;

    // Start is called before the first frame update
    void Start()
    {
        this.renderTexture = new RenderTexture(TexResolution, TexResolution, 24);
        this.renderTexture.enableRandomWrite = true;
        this.renderTexture.Create();

        this.renderer = GetComponent<Renderer>();
        renderer.enabled = true;

        UpdateTextureFromCompute();
    }

    private void UpdateTextureFromCompute()
    {
        int kernelHande = Shader.FindKernel("CSMain");
        Shader.SetInt("RandOffset", (int)(Time.timeSinceLevelLoad * 100));

        Shader.SetTexture(kernelHande, "Result", renderTexture);
        Shader.Dispatch(kernelHande, TexResolution / 8, TexResolution / 8, 1);

        renderer.material.SetTexture("_BaseMap", renderTexture);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateTextureFromCompute();
        }
    }
}
