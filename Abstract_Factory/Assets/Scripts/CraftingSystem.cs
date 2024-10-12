using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DependentFactory;
using static RelatedFactory;

public class CraftingSystem : MonoBehaviour
{
    void Start()
    {
        // Since we rely on abstraction it is super easy to simply switch factories...
        IAbstractFactory blacksmithFactory = new BlacksmithFactory();
        //...like so. This time we used the factory of factories. We couldve also used it directly in the constructor
        IAbstractFactory forgeFactory = MetaFactory.GetFactory("Forge");

        // factories can be changed exactly as above
        AbstractRecipeFactory swordRecipeFactory = new SilverSwordUpgrade();

        Client client = new Client(forgeFactory, swordRecipeFactory);
        client.RunFactoryProcesses();
    }
}
