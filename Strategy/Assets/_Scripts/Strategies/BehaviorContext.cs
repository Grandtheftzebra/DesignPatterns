using UnityEngine;

[RequireComponent(typeof(Player))]
public class BehaviorContext : MonoBehaviour
{
    public SO_Strategy Strategy;

    [HideInInspector] public Player Player;
    
    
    void Start()
    {
        Player ??= GetComponent<Player>();
        Strategy.Think();
    }

    // Update is called once per frame
    void Update()
    {
        Strategy.React(this);
    }
}
