using System;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradePickUp : MonoBehaviour
{
    [SerializeField] private SO_Visitor _upgradeVisitor;

    private void OnCollisionEnter(Collision other)
    {
        bool isPlayer = other.gameObject.TryGetComponent<Player>(out Player player);
        
        if(isPlayer) player.Accept(_upgradeVisitor);
        
        Destroy(this.gameObject);
    }
}