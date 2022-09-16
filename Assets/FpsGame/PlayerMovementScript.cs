using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{

    public SlimeMoldScript slimeMoldScript;

    public CharacterController CharacterController;
    public float WalkSpeed;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -30F;
    public float maximumY = 30F;
    float rotationX = 0F;
    float rotationY = 0F;
    private List<float> rotArrayX = new List<float>();
    float rotAverageX = 0F;
    private List<float> rotArrayY = new List<float>();
    float rotAverageY = 0F;
    public float frameCounter = 20;
    Quaternion originalRotation;

    public Vector2 hurtOffset = new Vector2();

    private Vector2 LastLookPosition = Vector2.zero;

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            //Gets rotational input from the mouse

            var mouseMovement = Mouse.current.delta;

            rotationY += mouseMovement.y.ReadValue() * sensitivityY;
            rotationX += mouseMovement.x.ReadValue() * sensitivityX;

            rotAverageY = rotationY = ClampAngle(rotationY, minimumY, maximumY);
            rotAverageX = rotationX;/////ClampAngle(rotationX, minimumX, maximumX);

            //Get the rotation you will be at next as a Quaternion
            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);

            //Rotate
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;

            var lookPosition = new Vector2(rotAverageX, rotAverageY);

            Vector2 lookDifference = (lookPosition - LastLookPosition);
            slimeMoldScript.LookMovement = lookDifference;

            LastLookPosition = lookPosition;
        }

        Move();
    }

    private void Move()
    {
        //var x = Input.GetAxis("Horizontal");
        //var z = Input.GetAxis("Vertical");

        //var movement = transform.right * x + transform.forward * z;

        //this.CharacterController.Move(movement * this.WalkSpeed * Time.deltaTime);
        //this.CharacterController.Move(Vector3.down);
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }
}