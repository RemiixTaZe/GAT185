using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    Dictionary<string, UnityEvent> events = new Dictionary<string, UnityEvent>();

    static EventManager instance = null;
    public static EventManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void Subscribe(string EventName, UnityAction listener)
    {
        UnityEvent unityEvent;
        if(events.TryGetValue(EventName, out unityEvent))
        {
            unityEvent.AddListener(listener);
        }
        else
        {
            unityEvent = new UnityEvent();
            unityEvent.AddListener(listener);
            events.Add(EventName, unityEvent);
        }
    }

    public void TriggerEvent(string EventName)
    {
        UnityEvent unityEvent;
        if (events.TryGetValue(EventName, out unityEvent))
        {
            unityEvent.Invoke();
        }
    }
}
