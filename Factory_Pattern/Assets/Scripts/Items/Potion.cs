using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    public void Equip()
    {
        Player player = GameObject.FindFirstObjectByType<Player>();
        player.SetColor(Color.green);

        Manager manager = GameObject.FindFirstObjectByType<Manager>();
        manager.HP += 5;
        manager.Boost++;
        
        Debug.Log($"The potion healed you by {5} health");
    }
}
