using UnityEngine;

public interface IVisitor
{
    public void VisitStats(Stats stats);
    public void VisitWeapon(Weapon weapon);
    public void VisitWeaponMod(WeaponMod weaponMod);
}
