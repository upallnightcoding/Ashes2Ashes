using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "fileName", menuName = "A2A/Channel Event Data")]
public class EventChannelDataSO : ScriptableObject
{
    public UnityAction<EventData> OnEventRaised;

    public void RaiseEvent(EventData data)
    {
        OnEventRaised?.Invoke(data);
    }
}
