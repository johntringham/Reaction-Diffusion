using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerMovement : MonoBehaviour
{
    public Transform DesiredTransform;

    public float PositionLerp = 10.0f;
    public float RotationSlerp = 10f;
    
    
    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = DesiredTransform.position;
        //this.transform.position = Vector3.Lerp(this.transform.position, DesiredTransform.position, PositionLerp * Time.deltaTime);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, DesiredTransform.rotation, RotationSlerp * Time.deltaTime);
    }
}
