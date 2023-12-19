using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager 
{
    private static AudioManager instance;

    
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AudioManager();
            }
            return instance;
        }
    }

    private AudioManager()
    {
        Debug.Log("AudioManager");

    }
    
    
    public void FailedMusic(AudioSource crashed)
    {
        crashed.Play();
    }
    public void EngineStart(AudioSource engineStart)
    {
        engineStart.Play();
    } 
  
}
