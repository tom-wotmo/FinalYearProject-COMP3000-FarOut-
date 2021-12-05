using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapons", menuName = "Items/Weapons")]
public class Weapons : ScriptableObject
{
    public GameObject weaponObj = null;
    public string weaponName = "New Weapon";
    public int weaponDamage = 1;
    public bool DamageWeapon = false;
    public bool WoodResourceWeapon = false;
    public bool RockResourceWeapon = false;

}
