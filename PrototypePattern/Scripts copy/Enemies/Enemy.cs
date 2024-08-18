using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IPrototype
{
    public int Damage;
    public string Message;
    public string Name;

    public Item Item;

    public Enemy(int dmg, string msg, string name, Item item)
    {
        Damage = dmg;
        Message = msg;
        Name = name;
        Item = item;
    }

    public void Print()
    {
        Debug.LogFormat($"{Message}! {Name} has a {Item.Name} and can hit for {Damage} HP.");
    }

    public IPrototype ShallowClone()
    {
        IPrototype newShallowPrototype = null;

        try
        {
            newShallowPrototype = (IPrototype)MemberwiseClone();
        }
        catch (Exception e)
        {
            Debug.Log($"Error cloning {e}");
        }

        return newShallowPrototype;
    }

    public IPrototype DeepClone()
    {
        Enemy newDeepClone = (Enemy)ShallowClone();

        newDeepClone.Item = new Item(this.Item.Name);

        return newDeepClone;
    }
}