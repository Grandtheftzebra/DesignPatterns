using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly object _threadLock = new object();
    private static bool _isQuitting = false;
    
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_isQuitting)
                return null;
            
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>();

                lock (_threadLock)
                {
                    if (_instance == null)
                    {
                        var singletonGO = new GameObject();
                        singletonGO.name = typeof(T) + "Persists";
                        _instance = singletonGO.AddComponent<T>();
                    
                        DontDestroyOnLoad(_instance.gameObject);
                        Debug.Log($"Could not find any Instance, so created {singletonGO.name}");
                    }
                }
            }

            return _instance;
        }
    }

    private void OnDestroy()
    {
        _isQuitting = true;
    }
}
