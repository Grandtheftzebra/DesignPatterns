using UnityEngine;

public class ParameterizedFactory : MonoBehaviour
{
    public virtual IItem Create(string itemName) => itemName switch
    {
        "Normal" => new Pebble(),
        "Rare" => new CursedKnife(),
        "Healing" => new Potion(),
        _ => HandleInvalidInput(itemName)
    };

    private IItem HandleInvalidInput(string itemName)
    {
        Debug.LogError($"{itemName} is not valid. Please visit {nameof(ParameterizedFactory)} Script for details.");
        return null;
    }
}

