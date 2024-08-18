using System.Collections.Generic;
using UnityEngine;

public class Factory<T> // Keep in mind a generic factory for only one enemy type or whatever might be overkill!
{
    private Dictionary<string, T> clones = new();

    public T this[string key]
    {
        get
        {
            if (clones.ContainsKey(key))
                return clones[key];
            else
                throw new KeyNotFoundException($"Key not found: {key}");
        }

        set
        {
            if (clones.ContainsKey(key))
                clones[key] = value;
            else
                clones.Add(key, value);
        }
    }
}
