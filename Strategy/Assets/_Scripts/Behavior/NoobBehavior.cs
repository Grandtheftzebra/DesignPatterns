using UnityEngine;

[CreateAssetMenu(fileName = "NoobBehavior", menuName = "Strategies/Behaviors/NoobBehavior")]
public class NoobBehavior : SO_Strategy
{
    public override void Think() => Debug.LogFormat($"Player Behavior -> Complete Noob...");

    public override void React(BehaviorContext context)
    {
        Vector3 movement = Vector3.forward * context.Player.MoveSpeed;
        Vector3 turning = Vector3.up * context.Player.TurnSpeed;
        
        context.Player.ConfigureInput(movement,turning);
    }
}
