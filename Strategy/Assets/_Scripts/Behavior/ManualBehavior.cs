using UnityEngine;

[CreateAssetMenu(fileName = "ManualBehavior", menuName = "Strategies/Behaviors/Manual")]
public class ManualBehavior : SO_Strategy
{
    public string ForwardInput;
    public string TurnInput;
    public override void Think() => Debug.LogFormat($"Real Player -> Manual Control");
    

    public override void React(BehaviorContext context)
    {
        float zInput = Input.GetAxis(ForwardInput) * context.Player.MoveSpeed;
        float xInput = Input.GetAxis(TurnInput) * context.Player.TurnSpeed;
        
        Vector3 movement = Vector3.forward * zInput;
        Vector3 turn = Vector3.up * xInput;
        
        context.Player.ConfigureInput(movement, turn);
    }
}