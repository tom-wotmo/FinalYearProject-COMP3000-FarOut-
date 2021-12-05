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
                damage = damage * 2;

                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {

                    Health.objHealth = Health.objHealth - damage;

                }
            }
            else
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
                damage = damage * 2;

                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {

                    Health.objHealth = Health.objHealth - damage;

                }
            }
            else
            {
                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {

                    Health.objHealth = Health.objHealth - damage;

                }
            }
        }
        if (currentWeapon.WoodResourceWeapon == true)
        {
            if (other.gameObject.tag == "WoodResource")
            {
                damage = damage * 2;

                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {

                    Health.objHealth = Health.objHealth - damage;

                }
            }
            else
            {
                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {

                    Health.objHealth = Health.objHealth - damage;

                }
            }
        }
    }
   
}
