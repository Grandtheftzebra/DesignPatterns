using UnityEngine;

public class CursedKnife : MonoBehaviour, IItem
{
    public void Equip()
    {
        Player player = GameObject.FindFirstObjectByType<Player>();
        player.SetColor(Color.black);
        
        Debug.Log($"Huh, now look at that! Seems you've been cursed.");
    }
}
