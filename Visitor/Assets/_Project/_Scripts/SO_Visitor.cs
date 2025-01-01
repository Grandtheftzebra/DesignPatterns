using UnityEngine;

[CreateAssetMenu(menuName = "Visitor", fileName = "Upgrade")]
public class SO_Visitor : ScriptableObject, IVisitor
{
    public int StatsBoost;
    public int DamageBoost;
    public int CriticalBoost;
    public int UpgradeMod;
    
    public void VisitStats(Stats stats)
    {
        if (StatsBoost == 0) return;

        stats.Intelligence += StatsBoost;
        stats.Strength += StatsBoost;

        Debug.LogFormat($"Intelligence -> {stats.Intelligence}, Strength -> {stats.Strength}");
    }

    public void VisitWeapon(Weapon weapon)
    {
        if (DamageBoost > 0)
        {
            weapon.Damage += DamageBoost;
            Debug.LogFormat($"Damage increased -> {weapon.Damage}");
        }
        
        if (CriticalBoost > 0)
        {
            weapon.Critical += CriticalBoost;
            Debug.LogFormat($"Critical increased -> {weapon.Critical}");
        }    
    }
    
    public void VisitWeaponMod(WeaponMod weaponMod)
    {
        if (UpgradeMod == 0) return;

        weaponMod.Level++;
        
        Debug.LogFormat($"{weaponMod.Name} level increased -> {weaponMod.Level}");
    }
}
