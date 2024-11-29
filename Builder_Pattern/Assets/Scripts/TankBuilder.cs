using UnityEngine;

public class TankBuilder : IBuilder
{
    private SupportAlly _supportAlly;
    public SupportAlly Ally => _supportAlly;
    
    public TankBuilder()
    {
        _supportAlly = new SupportAlly("Tank");
    }

    public void BuildFrame()
    {
        GameObject go = Utilities.CreateFromSO("Steel Frame");
        _supportAlly.AddComponent(go);
    }

    public void BuildMotor()
    {
        GameObject go = Utilities.CreateFromSO("Heavy Treads");
        _supportAlly.AddComponent(go);
    }

    public void BuildWeapon()
    {
        GameObject go = Utilities.CreateFromSO("Mortar");
        _supportAlly.AddComponent(go);
    }
}
