using UnityEngine;

public interface IObserver
{
    public void NotifiedBy(Publisher publisher, string eventName);
}
