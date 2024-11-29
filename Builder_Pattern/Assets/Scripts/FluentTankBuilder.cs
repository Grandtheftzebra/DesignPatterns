using UnityEngine;

public class FluentTankBuilder : IFluentBuilder
{
    private SupportAlly _supportAlly;
    public SupportAlly Ally => _supportAlly;
    
    public FluentTankBuilder()
    {
        _supportAlly = new SupportAlly("Tank");
    }

    public IFluentBuilder BuildFrame()
    {
        GameObject go = Utilities.CreateFromSO("Steel Frame");
        _supportAlly.AddComponent(go);

        return this;
    }

    public IFluentBuilder BuildMotor()
    {
        GameObject go = Utilities.CreateFromSO("Heavy Treads");
        _supportAlly.AddComponent(go);
        
        return this;
    }

    public IFluentBuilder BuildWeapon()
    {
        GameObject go = Utilities.CreateFromSO("Mortar");
        _supportAlly.AddComponent(go);
        
        return this;
    }
}