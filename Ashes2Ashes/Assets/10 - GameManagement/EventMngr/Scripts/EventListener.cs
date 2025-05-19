using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public GameEvent gameEvent;

    public UnityEvent<EventData> response;

    public void OnEventRaised(EventData eventData)
    {
        response.Invoke(eventData);
    }

    public void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    public void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }
}
