
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionWon : MonoBehaviour
{
    [SerializeField]GameEventSubject _gameEventSubject;
    //public GameObject levelWon;
    //private GameManager gameManager;
    // public TextMeshProUGUI statusText;
    private CarControl carControl;

    private void Awake()
    {
       // gameManager = FindObjectOfType<GameManager>();

        carControl = FindObjectOfType<CarControl>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*Debug.Log("Won");
            levelWon.SetActive(true);*/
           _gameEventSubject.NotifyListeners("Won");
            //carControl.levelWonFreeze = true; 
            other.GetComponent<CarControl>().levelWonFreeze = true;
            
            
            
        }
        
    }
   




}
