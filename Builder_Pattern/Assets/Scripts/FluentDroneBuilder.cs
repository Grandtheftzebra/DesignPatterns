using UnityEngine;

public class FluentDroneBuilder : IFluentBuilder
{
    private SupportAlly _supportAlly;
    public SupportAlly Ally => _supportAlly;
    
    public FluentDroneBuilder()
    {
        _supportAlly = new SupportAlly("Drone");
    }

    public IFluentBuilder BuildFrame()
    {
        GameObject go = Utilities.CreateFromSO("Titanium Hull");
        _supportAlly.AddComponent(go);

        return this;
    }

    public IFluentBuilder BuildMotor()
    {
        GameObject go = Utilities.CreateFromSO("Fiberglass Wings");
        _supportAlly.AddComponent(go);
        
        return this;
    }

    public IFluentBuilder BuildWeapon()
    {
        GameObject go = Utilities.CreateFromSO("Missiles");
        _supportAlly.AddComponent(go);
        
        return this;
    }
}