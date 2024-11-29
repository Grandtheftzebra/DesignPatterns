using UnityEngine;

/// <summary>
/// The director class in the Builder pattern has one job and one job only – to use the builder interface
/// methods to assemble a complex product object. The director class shouldn’t know about anything other than the builder interface – not the product, not the concrete builders, not the client,
/// nothing. This way, our director never needs to know what concrete builders it’s using to construct
/// which objects, making the client code less prone to breaking when you swap concrete builders.
/// </summary>
public class Director 
{
    public void ConstructWith(IBuilder builder)
    {
        builder.BuildFrame();
        builder.BuildMotor();
        builder.BuildWeapon();
    }
    
    // Storing concrete builders in a director class
    // The director class we’ve written is lean and mean, but you might come across a director variation in the wild that stores a concrete builder instance on initialization.
    // This is fine if you need to use the same concrete builder in more than one construction
    // method, but it’s over-optimization if you don’t. Take a look at the following code to
    // get an idea of when this might be useful:
    
    // public class Director
    // {
    //     private IBuilder _builder;
    //     public Director(IBuilder newBuilder)
    //     {
    //         _builder = newBuilder;
    //     }
    //     public void LoadoutA()
    //     {
    //         _builder.BuildFrame();
    //         _builder.BuildMotor();
    //         _builder.BuildWeapon();
    //     }
    //     public void LoadoutB()
    //     {
    //         _builder.BuildFrame();
    //         _builder.BuildMotor();
    //     }
    // }
}
