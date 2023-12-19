using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager :  MonoBehaviour
{
    [HideInInspector]
    public int index;
    public GameObject[] cars;

    [SerializeField] GameEventSubject gameEventSubject;
   

    
   


    private void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        Debug.Log("Value Transferred index: " + index);
        

        Vector3 pos = GameObject.Find("CarHolder").transform.position;
        Quaternion rotation = GameObject.Find("CarHolder").transform.rotation;

        GameObject car = Instantiate(cars[index], pos, rotation);
    }
   
  

    public void LoadNextLevel()
    {

            if (SceneManager.GetActiveScene().buildIndex != 10)  
            {
                Debug.Log("Scene Count: " + SceneManager.sceneCount);
                Debug.Log("buildIndex: " + SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Loading Next Level");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            else
            {
                Invoke("Close", 4f);
            }

    }
    public void Pause()
    {
        gameEventSubject.NotifyListeners("Paused");
    }
    public void Resume()
    {
        gameEventSubject.NotifyListeners("Resumed");
    }
    public void Restart()
    {
        gameEventSubject.NotifyListeners("Restart");
    }

    public void Close()
    {
        Debug.Log("closing");
        Application.Quit();
    }





}
