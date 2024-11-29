using UnityEngine;

public class BaseBattleState : State
{
    protected BattleSM stateMachine;
    protected readonly WaitForSeconds waitforOneSecond = new WaitForSeconds(1f);
    protected readonly WaitForSeconds waitForTwoSeconds = new WaitForSeconds(2f);

    public BaseBattleState(BattleSM stateMachine) => this.stateMachine = stateMachine;

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetKeyDown(KeyCode.Space)) Manager.Instance.Pause();
    }
}
