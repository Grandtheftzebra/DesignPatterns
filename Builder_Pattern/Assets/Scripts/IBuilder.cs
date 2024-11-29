using UnityEngine;

/// <summary>
/// Interface every Builder class needs to implement, but not every method has to be used. If a class does not need any method, just leave it empty.
/// </summary>
public interface IBuilder
{
    public SupportAlly Ally { get; }
    public void BuildFrame();
    public void BuildMotor();
    public void BuildWeapon();
    
}
