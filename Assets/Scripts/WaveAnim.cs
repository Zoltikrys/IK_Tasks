using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WaveAnim : MonoBehaviour
{
    public Transform IKTarget; // Assign the IK target for the arm
    public MultiRotationConstraint multiRotationConstraint; // Reference to the multi-rotation constraint
    public float waveAmplitude = 0.2f; // Adjust the wave height
    public float waveFrequency = 2.0f; // Adjust the wave speed
    public float rotationAmplitude = 15.0f; // Maximum rotation angle for the constraint
    private Vector3 initialPosition;
    private float initialRotationWeight;

    void Start()
    {
        // Store the initial position of the IK target
        if (IKTarget != null)
        {
            initialPosition = IKTarget.position;
        }

        // Store the initial weight of the multi-rotation constraint
        if (multiRotationConstraint != null)
        {
            initialRotationWeight = multiRotationConstraint.weight;
        }
    }

    void Update()
    {
        if (IKTarget != null)
        {
            // Create the waving motion using a sine wave
            float waveOffset = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
            IKTarget.position = new Vector3(initialPosition.x, initialPosition.y + waveOffset, initialPosition.z);
        }

        if (multiRotationConstraint != null)
        {
            // Rotate based on the wave motion using the sine wave
            float rotationOffset = Mathf.Sin(Time.time * waveFrequency) * rotationAmplitude;

            // Apply the rotation to the multi-rotation constraint's weight
            multiRotationConstraint.weight = initialRotationWeight + rotationOffset / 100.0f;
        }
    }
}
