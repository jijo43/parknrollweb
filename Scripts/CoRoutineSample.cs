
using System.Collections;
using UnityEngine;

public class CoRoutineSample : MonoBehaviour
{
    public GameObject _cube;
    public GameObject _capsule;

    public float rotateAmount = 2f;
    //public int TicksPerSecond = 60;

    private bool doneRotation = false;

    private void Update()
    {

        
       
        StartCoroutine(RotateCapsule(3f));


    }

    private IEnumerator RotateCube()
    {
        if(doneRotation)
        {
            _capsule.transform.rotation = Quaternion.identity;
        }
        _cube.transform.Rotate(Vector3.up * rotateAmount);
        yield return null;
    }

    IEnumerator RotateCapsule(float duration)
    {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            _capsule.transform.rotation = startRot * Quaternion.AngleAxis(t/duration*360f , Vector3.right); //or transform.right if you want it to be locally based
            yield return null;
        }
        transform.rotation = startRot;
        StartCoroutine(RotateCube());   
    }
}
