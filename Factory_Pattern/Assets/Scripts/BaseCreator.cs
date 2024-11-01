using UnityEngine;

/// <summary>
/// Good approach for when you have a set amount of Items in your game and do not intend to increase the amount of items
/// </summary>
public abstract class BaseCreator : MonoBehaviour
{
    public GameObject Spawner { get; protected set; }
    public GameObject Model { get; protected set; }

    public BaseCreator(GameObject model)
    {
        Spawner = new GameObject();
        Model = model;
    }
    
    public abstract IItem Create();
}
