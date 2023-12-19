using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] GameEventSubject gameEventSubject;


    public GameObject pauseMenuPanel;
    public GameObject levelFailed;
    public GameObject levelWon;

    private void OnEnable()
    {
        gameEventSubject.AddListener(this);
    }
    private void OnDisable()
    {
        gameEventSubject.RemoveListener(this);
    }

    public void OnGameEvent(string eventName)
    {
        if (eventName == "Paused")
        {
            Pause();
        }
        if (eventName == "Resumed")
        {
            Resume();
        }
        if (eventName == "Restart")
        {
            Restart();
        }
       
        if (eventName == "Hit")
        {
            Debug.Log("hit Message");
            levelFailed.SetActive(true);

        }
        if (eventName == "Won")
        {
            Debug.Log("Won");
            levelWon.SetActive(true);
        }
       /* switch(eventName)
        {
            case "Paused": Pause();break;
            case "Resumed": Resume();break;
            case "Restart": { Restart(); break; }
            case "HitOnObstacle": { levelFailed.SetActive(true); break; }
            
            case "Won": levelWon.SetActive(true);  break;
            
        }*/
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    
  
    public void Close()
    {
        Debug.Log("closing");
        Application.Quit();
    }
}
