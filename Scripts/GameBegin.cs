using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBegin : MonoBehaviour, IGameEventListener
{
    [SerializeField] GameEventSubject gameEventSubject;
    [SerializeField] CarControl carControl;

    public GameObject instruction;
    public GameObject button;

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
        if (eventName == "GameBegins")
        {
            carControl.gameBegins = true;
            instruction.SetActive(false);
            button.SetActive(false);
        }
    }

}
