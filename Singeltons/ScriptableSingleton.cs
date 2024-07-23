using System;
using UnityEngine;

public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] singletons = Resources.LoadAll<T>("");

                if (singletons == null || singletons.Length < 1)
                    throw new System.Exception("No " + typeof(T).Name + " singeltons were found");
                else if (singletons.Length > 1)
                    Debug.LogWarning("More than one " + typeof(T).Name + " singletons were found!");

                _instance = singletons[0];
                Debug.Log("Singleton feteched " + typeof(T).Name);


            }

            return _instance;
        }
    }
}
