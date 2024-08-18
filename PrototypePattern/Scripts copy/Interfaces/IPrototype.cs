using UnityEngine;
using System;

public interface IPrototype
{
    public IPrototype ShallowClone();
    public IPrototype DeepClone();
}
