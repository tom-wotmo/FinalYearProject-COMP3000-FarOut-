using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public Weapons currentWeapon;

    private void OnTriggerEnter(Collider other)
    {
        int damage = currentWeapon.weaponDamage;

        if (currentWeapon.DamageWeapon == true)
        {
            if (other.gameObject.tag == "Humanoid")
            {

                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {

                    Health.objHealth = Health.objHealth - damage;

                }

            }
          
        }
        if (currentWeapon.RockResourceWeapon == true)
        {
            if (other.gameObject.tag == "RockResource")
            {

                if (other.TryGetComponent<ObjectHealth>(out var Health))
                {

                    Health.currObjHealth = Health.currObjHealth - damage;

                }
            }
            else
            {
                //cannot use this weapon on anything else but Rocks
                damage = damage * 0;

                if (other.TryGetComponent<ObjectHealth>(out var iHealth))
                {

                    iHealth.currObjHealth = iHealth.currObjHealth - damage;

                }
            }
        }
        if (currentWeapon.WoodResourceWeapon == true)
        {
            if (other.gameObject.tag == "WoodResource")
            {
               
                if (other.TryGetComponent<ObjectHealth>(out var Health))
                {

                    Health.currObjHealth = Health.currObjHealth - damage;

                }
            }
            else
            {
                //cannot use this weapon on anything else but wood
                damage = damage * 0;

                if (other.TryGetComponent<ObjectHealth>(out var iHealth))
                {

                    iHealth.currObjHealth = iHealth.currObjHealth - damage;

                }
            }
        }
    }

}
