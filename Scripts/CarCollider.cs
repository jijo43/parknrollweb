using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollider : MonoBehaviour
{

    [SerializeField] GameEventSubject _gameEventSubject;



    public GameObject levelFailed;

    
    

    private CarControl carControl;


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


    private void Awake()
    {
        carControl = FindObjectOfType<CarControl>();
        
        

    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            _gameEventSubject.NotifyListeners("Hit");
            //  levelFailed.SetActive(true);

            carControl.levelFailedFreeze = true;
            Invoke("RestartGame", 6f);
        }
        if (other.CompareTag("Wall"))
        {

            // levelFailed.SetActive(true);
            _gameEventSubject.NotifyListeners("Hit");
            carControl.levelFailedFreeze = true;
            Invoke("RestartGame", 6f);

        }
        if (other.CompareTag("Obstacle"))
        {

            //  levelFailed.SetActive(true);
            _gameEventSubject.NotifyListeners("Hit");
            carControl.levelFailedFreeze = true;
            Invoke("RestartGame", 6f);


        }
        
    }*/
  
        
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
          
            _gameEventSubject.NotifyListeners("Hit");
           levelFailed.SetActive(true);

            carControl.levelFailedFreeze = true;
            Invoke("RestartGame", 6f);
        }
        else if (collision.collider.CompareTag("Building"))
        {
            _gameEventSubject.NotifyListeners("Hit");
            

            levelFailed.SetActive(true);
            carControl.levelFailedFreeze = true;
            Invoke("RestartGame", 6f);
        }
       else if (collision.collider.CompareTag("Obstacle"))
        {
                _gameEventSubject.NotifyListeners("Hit");
            levelFailed.SetActive(true);
           
            carControl.levelFailedFreeze = true;
            Invoke("RestartGame", 6f);
        }
        
    }

}
