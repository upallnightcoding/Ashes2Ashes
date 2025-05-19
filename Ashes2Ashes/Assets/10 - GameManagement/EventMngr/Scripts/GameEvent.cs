using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "fileName", menuName = "A2A/Game Event")]
public class GameEvent : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void Raise() => Raise(null);

    public void Raise(EventData data)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(data);
        }
    }

    public void RegisterListener(EventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnRegisterListener(EventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
