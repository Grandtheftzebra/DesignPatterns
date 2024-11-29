using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Publisher : MonoBehaviour
{
    private List<IObserver> _observers = new();

    protected void OnDisable()
    {
        NotifyAll("PublisherDestroyed");
    }

    public void AddObserver(IObserver observer) => _observers.Add(observer);
    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    protected void NotifyAll(string eventName)
    {
        foreach (var observer in _observers)
        {
            observer.NotifiedBy(this, eventName);
        }
    }
}
