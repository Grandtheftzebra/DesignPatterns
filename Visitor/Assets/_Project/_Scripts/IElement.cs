using UnityEngine;

public interface IElement
{
    public void Accept(IVisitor visitor);
}
