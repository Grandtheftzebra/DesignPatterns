using System.Collections;
using UnityEngine;

public class PlayerState : BaseBattleState
{
    private bool _isDead;
    private int _remainingMoves;
    
    public PlayerState(BattleSM stateMachine) : base(stateMachine)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log($"I give you hell MoFo!");

        Manager.Instance.Player.ChangeColor(Color.green);
        _remainingMoves = 1;

        yield break;
    }

    public override void HandleInput()
    {
        if (_remainingMoves <= 0) return;
        
        Debug.Log($"Entered Handle Input");

        if (!Manager.Instance.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _remainingMoves--;
                _isDead = Manager.Instance.Enemy.TakeDamage(1);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                _remainingMoves--;
                Manager.Instance.Player.Heal();
            }
            else
            {
                base.HandleInput();
            }
        }
        else
        {
            base.HandleInput();
        }
    }

    public override void CheckState()
    {
        if (_isDead) stateMachine.ChangeStateTo(stateMachine.EndBattle);
        else if (_remainingMoves <= 0) stateMachine.ChangeStateTo(stateMachine.EnemyTurn);
    }

    public override IEnumerator Exit()
    {
        yield return new WaitForSeconds(1);
        
        Debug.Log($"Gotta rest for now.");
        Manager.Instance.Player.ChangeColor(Color.blue);
    }
}
