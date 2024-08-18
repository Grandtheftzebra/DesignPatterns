using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseEnemy : MonoBehaviour, ICopy
{
    [SerializeField] protected int damage;
    [SerializeField] protected string message;
    [SerializeField] protected string name;

    public void OnEnable()
    {
        Debug.LogFormat($"{message} - an {name} entered the arena.");
    }

    public virtual void Attack()
    {
        Debug.LogFormat($"{name} attacks for {damage} HP!");
    }

    public ICopy Copy(Transform parent)
    {
        BaseEnemy clone = Instantiate(this);

        Vector3 clonePosition = new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7));
        
        clone.transform.SetParent(parent);
        clone.transform.localPosition = clonePosition;

        return clone;
    }
    
    
}