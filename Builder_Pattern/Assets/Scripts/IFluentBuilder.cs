using UnityEngine;

public interface IFluentBuilder
{
    public SupportAlly Ally { get; }
    public IFluentBuilder BuildFrame();
    public IFluentBuilder BuildMotor();
    public IFluentBuilder BuildWeapon();
    
}


