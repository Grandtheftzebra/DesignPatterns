using UnityEngine;

public class Frostmourne : MonoBehaviour, IItem
{
    public void Equip()
    {
        Debug.Log("All enemies around you die, lol!");
    }
}
