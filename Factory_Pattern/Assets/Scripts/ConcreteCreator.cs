using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Suited for when you want a scalable approach to factories
/// </summary>
public class ConcreteCreator 
{
    public GameObject Spawner { get; protected set; }
    
    public GameObject PebbleModel { get; protected set; }
    public GameObject KnifeModel { get; protected set; }
    public GameObject PotionModel { get; protected set; }

    protected List<IItem> _items = new List<IItem>();
    public List<IItem> Items => _items;

    public ConcreteCreator()
    {
        Spawner = new GameObject();
        Spawner.name = "Concrete Factory";
        
        PebbleModel = Resources.Load("Pebble") as GameObject;
        KnifeModel = Resources.Load("Knife") as GameObject;
        PotionModel = Resources.Load("Potion") as GameObject;

        CreateInventory();
    }

    public virtual IItem NormalItem()
    {
        GameObject pebble = GameObject.Instantiate(PebbleModel);
        IItem item = pebble.AddComponent<Pebble>();

        pebble.transform.position = new Vector3(-2.2f, 0.3f, -7f);
        pebble.transform.SetParent(Spawner.transform);
        _items.Add(item);

        return pebble.GetComponent<Pebble>();
    }

    public virtual IItem RareItem()
    {
        GameObject knife = GameObject.Instantiate(KnifeModel);
        IItem item = knife.AddComponent<CursedKnife>();
        
        knife.transform.position = new Vector3(-0.6f, 0.3f, -7.6f);
        knife.transform.SetParent(Spawner.transform);
        _items.Add(item);

        Debug.Log($"return of knife.getComponent is {knife.GetComponent<CursedKnife>()}");
        return knife.GetComponent<CursedKnife>();
    }

    public virtual IItem HealingItem()
    {
        GameObject potion = GameObject.Instantiate(PotionModel);
        IItem item = potion.AddComponent<Potion>();
        
        potion.transform.position = new Vector3(0.6f, 0.3f, -7f);
        potion.transform.SetParent(Spawner.transform);
        _items.Add(item);

        return potion.GetComponent<Potion>();
    }
    
    public List<IItem> CreateInventory()
    {
        return new List<IItem>()
        {
            NormalItem(),
            RareItem(),
            HealingItem()
        };
    }
}

public class HealingFactory : ConcreteCreator
{
    public override IItem NormalItem() => new Potion();
    public override IItem RareItem() => new Potion();
}
