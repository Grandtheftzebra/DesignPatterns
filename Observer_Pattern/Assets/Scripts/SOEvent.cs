using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvent", menuName = "Scriptable Objects/Events/SO Event")]
public class SOEvent : ScriptableObject
{
    private List<SOSubscriber> _subscribers = new();

    public void NotifyAll()
    {
        for (int i = 0; i < _subscribers.Count; i++)
        {
            _subscribers[i].OnEventInvoked();
        }
    }

    public void Subscribe(SOSubscriber subscriber)
    {
        if (_subscribers.Contains(subscriber)) return;
        
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(SOSubscriber subscriber)
    {
        if (!_subscribers.Contains(subscriber)) return;

        _subscribers.Remove(subscriber);
    }
}
