using UnityEngine;

public class PlayerPrefsVisitor : IVisitor
{
    public void VisitStats(Stats stats)
    {
       PlayerPrefs.SetInt("_intelligence", stats.Intelligence);
       PlayerPrefs.SetInt("_strength", stats.Strength);
    }

    public void VisitWeapon(Weapon weapon)
    {
        PlayerPrefs.SetString("_weaponName", weapon.Name);
        PlayerPrefs.SetInt("_weaponDamage", weapon.Damage);
        PlayerPrefs.SetInt("_weaponCritical", weapon.Critical);
    }

    public void VisitWeaponMod(WeaponMod weaponMod)
    {
        PlayerPrefs.SetString("_weaponMod" + weaponMod.Slot, weaponMod.Name + weaponMod.Level);
    }
}
