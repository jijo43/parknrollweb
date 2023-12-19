using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CarAIControl : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = -10f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    private List<Transform> nodes;
    private int currentNode = 0;

    
    private void Start() 
    {
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);

            }
                
        }
    }
    private void FixedUpdate()
    {
        ApplySteering();
        Drive();
        CheckWayPointDistance();
    }
    private void ApplySteering()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        print(relativeVector);
        float newSteer = (relativeVector.x / relativeVector.magnitude)*  maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }
    private void Drive()
    {
        wheelFL.motorTorque = -100f;
        wheelFR.motorTorque = -100f;
    }
    private void CheckWayPointDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            if(currentNode == nodes.Count-1 ) {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }




}
