using UnityEngine;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Object = System.Object;

public class ReflectionFactory
{
    public GameObject Spawner { get; protected set; }
    
    private Dictionary<string, Type> _items = new Dictionary<string, Type>();
    public Dictionary<string, Type> Items => _items;

    // Adds a class constructor and uses the Assembly class to get all IItem class types in the project
    public ReflectionFactory()
    {
        Spawner = new GameObject();
        Spawner.name = "Reflection Factory";
        
        Type[] itemTypes = Assembly.GetAssembly(typeof(IItem)).GetTypes();
        Debug.Log($"Item Types are {itemTypes}");

        // Filters all types to discard interfaces and returns objects that have implemented the IItem interface
        IEnumerable<Type> filteredItems = itemTypes.Where(item => !item.IsInterface && typeof(IItem).IsAssignableFrom(item));
        
        // Loops through the list of filtered items and adds the temporary item’s type name and type to the dictionary of items
        foreach (var type in filteredItems)
        {
            _items.Add(type.Name, type);
        }
    }

    public IItem Create(string itemName, GameObject model, Vector3 position)
    {
        if (_items.ContainsKey(itemName))
        {
            // If the item exists, we cast it as a new Type variable
            Type type = _items[itemName];

            // Instantiates an item GameObject using the model parameter and adds the appropriate item script as a component
            GameObject obj = GameObject.Instantiate(model);
            IItem item = obj.AddComponent(type) as IItem;

            // Sets the item object’s position and parent, and then returns the item component script
            obj.transform.position = position;
            obj.transform.SetParent(Spawner.transform);

            return obj.AddComponent(type) as IItem;

            // // Uses the Activator class to create a new instance of the given type and cast it as an IItem.
            // IItem item = Activator.CreateInstance(type) as IItem;
            //
            // return item;
        }

        return null;
    }
}
