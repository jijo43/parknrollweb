
using UnityEngine;

public class AICarCollider : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject character;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (other.CompareTag("Wall"))
        {
            Invoke("SpawnCharacter",0.5f);
        }
    }
    public void SpawnCharacter()
    {
       character.SetActive(true);

    }
}
