using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IElement
{
    public int Intelligence = 1;
    public int Strength = 1;
    
    public void Accept(IVisitor visitor)
    {
        visitor.VisitStats(this);
    }
}