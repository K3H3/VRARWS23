using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool winningCondition = false;
    
    // Settings
    [SerializeField] private float motorForce, breakForce;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    public void Update()
    {
        if (winningCondition)
        {
            DestroyGameObjectWithTag("Pickup");
            //confetti;
        }
    }
    
    void DestroyGameObjectWithTag(string tag)
    {
        // Find all GameObjects with the specified tag
        GameObject[] pickups = GameObject.FindGameObjectsWithTag(tag);

        // Loop through each pickup and destroy or disable it
        foreach (GameObject pickup in pickups)
        {
            // Check if the current pickup is the one calling the script
            if (pickup == gameObject)
            {
                // Destroy or disable the pickup
                Destroy(pickup, 3);
                break; // Break out of the loop once the desired pickup is handled
            }
        }
    }

    public void Move(float input)
    {
        // Reverse the motor torque calculation for forward movement.
        float motorTorque = input >= 0f ? -input * motorForce : input * motorForce;
        float brakeTorque = input < 0f ? Mathf.Abs(input) * breakForce : 0f;

        // Set motor torque and brake torque for both front wheels.
        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;

        // Apply brake torque to all wheels.
        frontLeftWheelCollider.brakeTorque = brakeTorque;
        frontRightWheelCollider.brakeTorque = brakeTorque;
        rearLeftWheelCollider.brakeTorque = brakeTorque;
        rearRightWheelCollider.brakeTorque = brakeTorque;

        // Update wheel positions.
        UpdateWheels();
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("FinishLine"))
        {
            return;
        }
        winningCondition = true;
        Debug.Log("Winning Condition: " + winningCondition);
    }

}
