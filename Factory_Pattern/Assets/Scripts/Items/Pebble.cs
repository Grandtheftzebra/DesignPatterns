using UnityEngine;

public class Pebble : MonoBehaviour, IItem
{
    public void Equip() => Debug.Log($"Just a pebble. Wow cool, you can throw it in the lake!");
}
