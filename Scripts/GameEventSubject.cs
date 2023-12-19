using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSubject :MonoBehaviour
{
    private List<IGameEventListener> listeners = new List<IGameEventListener> ();

    public void AddListener(IGameEventListener listener)
    {
        listeners.Add (listener);
    }
    public void RemoveListener(IGameEventListener listener)
    {
        listeners.Remove(listener);
    }
    public void NotifyListeners(string eventName)
    {
        foreach (var listener in listeners)
        {
            listener.OnGameEvent(eventName);
        }
    }
}
