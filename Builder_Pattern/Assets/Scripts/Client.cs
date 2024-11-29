using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public Text BlueprintLog;

    public void Build()
    {
        // Code for the fluent builder pattern

        IBuilder builder = new DroneBuilder();

        SupportAlly fluentAlly = new FluentDroneBuilder()
            .BuildFrame()
            .BuildMotor()
            .BuildWeapon()
            .Ally;

        BlueprintLog.text = fluentAlly.GetBluePrint();

        // Code for the Builder Pattern

        // IBuilder builder = new TankBuilder();
        //
        // Director director = new Director();
        // director.ConstructWith(builder);
        //
        // SupportAlly ally = builder.Ally;
        //
        // BlueprintLog.text = ally.GetBluePrint();
    }
}

// Disclaimer:
// Customizing object components
// One of the main complaints about the Builder pattern is how hardcoded and static
// it can be, which begs the question of why we’re using it in the first place. This is especially true in Unity, as Prefabs are more UI-friendly to designers and programmers.
// However, that is only true if the Prefabs are themselves static and your scenarios only
// need to instantiate them. In those cases, the Prototype or Abstract Factory patterns
//     would be a better fit.
//     However, when you need to create customizable objects made of different and interchangeable parts, the Builder pattern comes in as a strong contender. I would even
//     argue the Builder pattern is more useful in Unity in these situations, as you can build
//     component parts out of ScriptableObjects or Prefabs, configure them however
// you want, and then assemble them into complex objects in a scene.
//     As for scaling and flexibility, you can easily add customization parameters to your
//     IBuilder interface methods on a component-by-component basis. There’s also
// nothing that says you can’t implement the Builder interface as an abstract class,
// meaning you could add optional overloaded builder methods with different parameter sets. In some sense, the Builder pattern is only as static as you make it – the
//     structure itself doesn’t require too much architecting upfront for what you get!