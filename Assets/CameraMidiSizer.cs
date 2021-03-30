using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMidiSizer : MonoBehaviour
{
    public float size;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.camera.orthographicSize = size;
    }
}
