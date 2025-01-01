using UnityEngine;

[CreateAssetMenu(fileName = "SearchAndDestroy", menuName = "Strategies/Behaviors/Search & Destroy")]
public class SearchAndDestroy : SO_Strategy
{
    public float SpeedMultiplier;
    
    public override void Think() => Debug.LogFormat($"Player Behavior -> Search & Destroy...");
    
    public override void React(BehaviorContext context)
    {
        GameObject enemy = null;

        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (enemy == null)
        {
            context.Player.ConfigureInput(Vector3.zero, Vector3.zero);
            return;
        }

        Vector3 targetVector = (enemy.transform.position - context.transform.position);
        context.transform.LookAt(enemy.transform);
        context.Player.ConfigureInput(targetVector * SpeedMultiplier, Vector3.zero);
    }
}
