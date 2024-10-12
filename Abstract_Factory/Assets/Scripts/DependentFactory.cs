using System;
using UnityEngine;

public class DependentFactory
{
    // Parameterized Factory
    public abstract class AbstractParameterizedRecipeFactory
    {
        public abstract Item GetItem(string name);
        public abstract UpgradeMaterial GetMaterial(string name);
    }
    
    // Don't forget that switch cases don't scale well. You can use reflection instead
    public class WeaponUpgradeFactory : AbstractParameterizedRecipeFactory
    {
        public override Item GetItem(string name)
        {
            Item item = name switch
            {
                "Sword" => new Sword(),
                "Axe" => new Axe(),
                _ => throw new NotImplementedException("This item is not in the game")
            };

            return item;
        }

        public override UpgradeMaterial GetMaterial(string name)
        {
            UpgradeMaterial material = name switch
            {
                "Silver" => new Silver(),
                "Dragonscale" => new DragonScale(),
                _ => throw new NotImplementedException("This material is not in the game.")
            };

            return material;
        }
    }

    // Normal Abstract Factory
    public abstract class AbstractRecipeFactory
    {
        public abstract Item GetItem();
        public abstract UpgradeMaterial GetUpgradeMaterial();
    }
    
    public class SilverSwordUpgrade : AbstractRecipeFactory
    {
        public override Item GetItem() => new Sword();

        public override UpgradeMaterial GetUpgradeMaterial() => new Silver();
    }
    
    public class DragonScaleAxeUpgrade : AbstractRecipeFactory
    {
        public override Item GetItem() => new Axe();

        public override UpgradeMaterial GetUpgradeMaterial() => new DragonScale();
    }

    public abstract class UpgradeMaterial
    {
        // Empty - in a real example there would be code
    }
    
    public abstract class Item
    {
        public abstract void Upgrade(UpgradeMaterial upgradeMaterial);
    }
    
    public class Silver : UpgradeMaterial{}
    public class DragonScale : UpgradeMaterial{}

    public class Sword : Item
    {
        public override void Upgrade(UpgradeMaterial upgradeMaterial)
        {
            if (upgradeMaterial.GetType().Name != "Silver")
            {
                Debug.Log("You need Silver to upgrade this Sword");
            }
            
            Debug.Log("Increased strength of the Sword with Silver material!");
        }
    }

    public class Axe : Item
    {
        public override void Upgrade(UpgradeMaterial upgradeMaterial)
        {
            if (upgradeMaterial.GetType().Name != "DragonScale")
            {
                Debug.Log("Wrong material. You need Dragon Scale");
            }
            
            Debug.Log("Increased strength of the Axe with Dragon Scale material!");
        }
    }
    
}