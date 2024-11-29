using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SOSubscriber : MonoBehaviour
{
    public SOEvent PublisherEvent;
    public UnityEvent Response;

    public void OnEnable() => PublisherEvent?.Subscribe(this);
    public void OnDisable() => PublisherEvent?.Unsubscribe(this);
    public void OnEventInvoked() => Response?.Invoke();
}
