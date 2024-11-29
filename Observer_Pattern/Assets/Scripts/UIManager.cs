using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IObserver
{
    public TextMeshProUGUI health;

    private Player _broadcasterPlayer;

    void Awake()
    {
        health.text += "10";
    }

    private void OnDisable()
    {
        if (_broadcasterPlayer != null)
        {
            _broadcasterPlayer.RemoveObserver(this);
            Debug.Log($"Observer removed from broadcaster in {typeof(UIManager)}");
        }
    }

    public void NotifiedBy(Publisher publisher, string eventName)
    {
        if (_broadcasterPlayer == null) _broadcasterPlayer = publisher.GetComponent<Player>();

        switch (eventName)
        {
            case "HealthUpdated":
                health.text = $"Health: {_broadcasterPlayer.Health}";
                break;
            case "PlayerDead":
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene);
                Debug.Log("Restart the level!");
                break;
            case "PublisherDestroyed":
                Debug.Log("Publisher has been destroyed");
                break;
        }
    }
    
    
}