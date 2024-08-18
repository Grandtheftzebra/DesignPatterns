using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSpawner : MonoBehaviour
{
    void Start()
    {
        Factory<IPrototype> factory = new Factory<IPrototype>();

        factory["Ogre"] = new Enemy(10, "ICH STEH MIT RÜCKEN AN DER WAND, HAND AN MEIM SCHWANZ", "Hafti-Ogre",
            new Item("Scharfe 9er"));

        factory["Knight"] = new Enemy(20, "I will kill you!", "Meta-Knight", new Item("Blacksword"));

        IPrototype ogrePrototype = (Enemy)factory["Ogre"].DeepClone();
        IPrototype knightPrototype = (Enemy)factory["Knight"].DeepClone();
        
        if (ogrePrototype is Enemy ogreEnemy)
            ogreEnemy.Print();
        
        if(knightPrototype is Enemy knightEnemy)
            knightEnemy.Print();

    }
}