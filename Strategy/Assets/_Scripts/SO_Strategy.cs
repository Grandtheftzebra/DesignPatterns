using UnityEngine;

public abstract class SO_Strategy : ScriptableObject
{
    public abstract void Think();

    public abstract void React(BehaviorContext context);
}
