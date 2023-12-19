using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianNavAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject path;
    public Transform[] pathPoints;
   

    public int index = 0;

    public float minDistance=2f;

    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        pathPoints = new Transform[path.transform.childCount];
        

        for (int i = 0; i < pathPoints.Length; i++)
        {
            
                pathPoints[i] = path.transform.GetChild(i);

            

        }

    }
    private void Update()
    {
        roam();
    }
    void roam()
    {
       if (Vector3.Distance(transform.position, pathPoints[index].position) < minDistance)
        {
            if (index > 0 && index < pathPoints.Length)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }

        }
        agent.SetDestination(pathPoints[index].position);
        animator.SetFloat("Vertical", !agent.isStopped ? 1 : 0);
    }

}
