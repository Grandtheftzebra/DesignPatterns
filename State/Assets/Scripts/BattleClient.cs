using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Manager))]
public class BattleClient : MonoBehaviour
{
    private BattleSM _battleSM;
    private WeatherSM _weatherSM;
    
    void Awake()
    {
        _battleSM = GetComponent<BattleSM>();
        _weatherSM = GetComponent<WeatherSM>();
    }

    void Update()
    {
        _battleSM.HandleInput();
        _battleSM.CheckState();
        
        _weatherSM.HandleInput();
        _weatherSM.CheckState();
    }
}