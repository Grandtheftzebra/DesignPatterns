using System.Collections;
using UnityEngine;

public class EnemyState : BaseBattleState
{
    private bool _isDead;
    private int _movesRemaining;

    public EnemyState(BattleSM stateMachine) : base(stateMachine)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log($"I am Batman!!!!");
        
        Manager.Instance.Enemy.ChangeColor(Color.green);
        _movesRemaining = 1;

        yield return waitforOneSecond;

        _isDead = Manager.Instance.Player.TakeDamage(1);
        _movesRemaining--;

        stateMachine.History.Pop();
    }

    public override void CheckState()
    {
        if (_isDead) stateMachine.ChangeStateTo(stateMachine.EndBattle);
        else if (_movesRemaining <= 0) stateMachine.ChangeStateTo(stateMachine.History.Peek());
    }

    public override IEnumerator Exit()
    {
        yield return waitforOneSecond;

        Debug.Log($"Next round you'll die!!!");
        
        Manager.Instance.Enemy.ChangeColor(Color.magenta);
    }
}
