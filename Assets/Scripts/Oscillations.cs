using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    UnityEngine.Vector3 startingPosition;
    [SerializeField] UnityEngine.Vector3 changingVector;
    [SerializeField] [Range(0,1)] float coefficient; 
    float period = 3f;   
    void Start()
    {
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()

    {
        Oscillation();
    }

     void Oscillation()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSin = MathF.Sin(tau * cycles);
        coefficient = (rawSin + 1f) / 2f;
        UnityEngine.Vector3 movementVector = coefficient * changingVector;

        transform.position = startingPosition + movementVector;
    }
}
