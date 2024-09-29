using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    [SerializeField] private ItemButton _buttonPrefab;

    // For larger projects this can be abstracted into a Scriptable Object
    [SerializeField] private GameObject _pebbleModel;
    [SerializeField] private GameObject _cursedKnifeModel;
    [FormerlySerializedAs("potionModel")] [SerializeField] private GameObject _potionModel;

    private void Start()
    {
        // Create GameObjects via Reflection Factory
        List<Vector3> positions = new List<Vector3>(3)
        {
            new Vector3(-2.2f, 0.3f, -7f),
            new Vector3(-0.6f, 0.3f, -7.6f),
            new Vector3(0.6f, 0.3f, -7f)
        };

        ReflectionFactory itemFactory = new ReflectionFactory();

        List<IItem> items = new List<IItem>(3)
        {
            itemFactory.Create("Pebble", _pebbleModel, positions[0]),
            itemFactory.Create("CursedKnife", _cursedKnifeModel, positions[1]),
            itemFactory.Create("Potion", _potionModel, positions[2])
        };

        foreach (var item in items)
        {
            ItemButton button = Instantiate(_buttonPrefab);
            
            button.Configure(item);
            button.transform.SetParent(this.transform);
        }

        // // Create Gameobjects via concrete class
        // ConcreteCreator concreteCreator = new ConcreteCreator();
        //
        // foreach (var item in concreteCreator.Items)
        // {
        //     ItemButton button = Instantiate(_buttonPrefab);
        //     
        //     button.Configure(item);
        //     button.transform.SetParent(this.transform);
        // }

        /*// Instantiation of GameObject via abstract class
        List<BaseCreator> factories = new List<BaseCreator>(3)
        {
            new PebbleFactory(_pebbleModel),
            new CursedKnifeFactory(_cursedKnifeModel),
            new PotionFactory(_potionModel)
        };

        foreach (var factory in factories)
        {
            var button = Instantiate(_buttonPrefab);
            IItem item = factory.Create();
            button.Configure(item);
            button.transform.SetParent(this.transform);
        }*/

        // // Reflection
        // ReflectionFactory itemFactory = new ReflectionFactory();
        //
        // List<IItem> items = new List<IItem>()
        // {
        //     itemFactory.Create("Pebble"),
        //     itemFactory.Create("CursedKnife"),
        //     itemFactory.Create("Potion"),
        //     
        // };
        //
        // foreach (var item in items)
        // {
        //     ItemButton button = Instantiate(_buttonPrefab);
        //     
        //     button.Configure(item);
        //     button.transform.SetParent(this.transform);
        // }

        // // Parameterized
        // ParameterizedFactory itemFactory = new CheatFactory();
        //
        // List<IItem> items = new List<IItem>()
        // {
        //     itemFactory.Create("Normal"),
        //     itemFactory.Create("Rare"),
        //     itemFactory.Create("Healing")
        // };
        //
        // foreach (var item in items)
        // {
        //     ItemButton button = Instantiate(_buttonPrefab);
        //     
        //     button.Configure(item);
        //     button.transform.SetParent(this.transform);
        // }

        /*// Concrete
        ConcreteCreator creator = new HealingFactory();
        var items = creator.CreateInventory();

        foreach (var item in items)
        {
            ItemButton button = Instantiate(_buttonPrefab);

            button.Configure(item);
            button.transform.SetParent(this.transform);
        }*/

        // Abstract
        /*List<BaseCreator> factories = new List<BaseCreator>()
        {
            new PebbleFactory(),
            new PotionFactory(),
            new CursedKnifeFactory()
        };

        foreach (var factory in factories)
        {
            ItemButton button = Instantiate(_buttonPrefab);

            IItem item = factory.Create();

            button.Configure(item);
            button.transform.SetParent(this.transform);
        }*/
    }
}