using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodResourceWeapon : MonoBehaviour
{
    public Weapons currentWeapon;

    private void OnTriggerEnter(Collider other)
    {
        int damage = currentWeapon.weaponDamage;

        if (other.gameObject.tag == "WoodResource")
        {
            damage = damage * 2;

            if (other.TryGetComponent<EnemyHealth>(out var Health))
            {

                Health.objHealth = Health.objHealth - damage;

            }
        }

    }

}
