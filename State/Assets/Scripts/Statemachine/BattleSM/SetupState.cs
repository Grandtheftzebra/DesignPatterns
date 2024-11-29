using System.Collections;
using UnityEngine;

public class SetupState : BaseBattleState
{
    public SetupState(BattleSM stateMachine) : base(stateMachine) { }

    public override IEnumerator Enter()
    {
        Debug.Log("Setting up the Arena");

        yield return waitForTwoSeconds;
        
        stateMachine.ChangeStateTo(stateMachine.PlayerTurn);

        Debug.Log("All set up, start the BAAAAAATTLEEEEE");
    }
}
