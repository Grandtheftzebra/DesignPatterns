using System;
using UnityEngine;

public class WeatherSM : SMContext
{
    public State Sunny;
    public State Cloudy;

    private void Start()
    {
        Sunny = new SunnyState(this);
        Cloudy = new CloudyState(this);
        
        ChangeStateTo(Sunny);
    }
}
