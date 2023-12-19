using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject _title;
    public GameObject playButton;
    public GameObject developer;

    private void Start()
    {
        _title.SetActive(true);
        Invoke("ShowDeveloper", 0.5f);
        
    }

    public void ShowPlayButton()
    {
        playButton.SetActive(true);
    }
    public void ShowDeveloper()
    {
        developer.SetActive(true);
        Invoke("ShowPlayButton", 1.5f);
    }
}
