using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SlimePathFollow : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    [SerializeField] float speed = 5;
    float distancedTravelled;

    bool speedChanging;
    float sinInput;
    [Range(0f,0.1f)]
    [SerializeField] float sinFrequency = 0.045f;

    [Range(1f, 2f)]
    [SerializeField] float speedMult = 1.25f;

    private void OnEnable()
    {
        speedChanging = false;
        sinInput = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distancedTravelled += SinCalc() * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distancedTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distancedTravelled);
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(-90, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    float SinCalc()
    {
        sinInput += sinFrequency;
        return ((speed * speedMult) + (speed * Mathf.Sin(sinInput * Mathf.PI)));
        
    }
}
