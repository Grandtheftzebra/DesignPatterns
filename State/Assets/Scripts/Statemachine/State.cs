using System.Collections;
using UnityEngine;

public abstract class State
{
    public virtual IEnumerator Enter()
    {
        yield break;        
    }

    public virtual void HandleInput() { }
    public virtual void CheckState() { }
    public virtual void FixedUpdate() { }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
