using UnityEngine;

public class CheatFactory : ParameterizedFactory
{
    public override IItem Create(string itemName) => itemName switch
    {
        "Normal" => new Frostmourne(),
        "Rare" => new Frostmourne(),
        _ => base.Create(itemName)
    };
}
