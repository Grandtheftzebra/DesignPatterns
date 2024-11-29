using System.Collections;
using UnityEngine;

public class EndState : BaseBattleState
{
    public EndState(BattleSM stateMachine) : base(stateMachine)
    {
        
    }

    public override IEnumerator Enter()
    {
        Debug.Log($"Saving game data");
        
        Application.Quit();
        
        yield break;
    }
}
