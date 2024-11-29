using UnityEngine;

public class DroneBuilder : IBuilder
{
    private SupportAlly _supportAlly;
    public SupportAlly Ally => _supportAlly;
    
    public DroneBuilder()
    {
        _supportAlly = new SupportAlly("Drone");
    }

    public void BuildFrame()
    {
        GameObject go = Utilities.CreateFromSO("Titanium Hull");
        _supportAlly.AddComponent(go);
    }

    public void BuildMotor()
    {
        GameObject go = Utilities.CreateFromSO("Fiberglass Wings");
        _supportAlly.AddComponent(go);
    }

    public void BuildWeapon()
    {
        GameObject go = Utilities.CreateFromSO("Missiles");
        _supportAlly.AddComponent(go);
    }
}
