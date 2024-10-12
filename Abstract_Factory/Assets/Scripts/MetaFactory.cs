using System;
using UnityEngine;
using static RelatedFactory;

public class MetaFactory
{
    public static IAbstractFactory GetFactory(string name)
    {
        IAbstractFactory factory = name switch
        {
            "Blacksmith" => new BlacksmithFactory(),
            "Forge" => new FusionFactory(),
            _ => throw new NotImplementedException("This factory is not in the game")
        };

        return factory;
    }
}
