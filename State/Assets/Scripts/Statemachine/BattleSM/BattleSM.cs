using System;
using UnityEngine;

public class BattleSM : SMContext
{
    public State Setup { get; private set; }
    public State PlayerTurn { get; private set; }
    public State EnemyTurn { get; private set; }
    public State EndBattle { get; private set; }

    private void Awake()
    {
        Setup = new SetupState(this);
        PlayerTurn = new PlayerState(this);
        EnemyTurn = new EnemyState(this);
        EndBattle = new EndState(this);
        
        ChangeStateTo(Setup);
    }
}
