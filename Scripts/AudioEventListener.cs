using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] GameEventSubject gameEventSubject;
   

    public AudioSource crashedEffect;
    public AudioSource engineStart;
    public AudioSource victory;
    //public AudioSource Bgm;

    //AudioManager audioManager = AudioManager.Instance;

    //Adding to Observer List
    private void OnEnable()
    {
        gameEventSubject.AddListener(this);
        //  audioManager.EngineStart(engineStart);
        engineStart.Play();
        //Invoke("BgmMusicRuns", 2f);
        
    }
    //Removing from Observer List
    private void OnDisable()
    {
        gameEventSubject.RemoveListener(this);
    }
    public void OnGameEvent(string eventName)
    {
        
        if (eventName == "Hit")
        {
           
          // audioManager.FailedMusic(crashedEffect);
          crashedEffect.Play();
           
            
        }if (eventName == "HitOnObstacle")
        {

            crashedEffect.Play();


        }
        if(eventName == "Won")
        {
            victory.Play();
        }
        
    }
    
}
