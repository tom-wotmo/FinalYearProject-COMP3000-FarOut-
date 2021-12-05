using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockResourceWeapon : MonoBehaviour
{
    public Weapons currentWeapon;

    private void OnTriggerEnter(Collider other)
    {
        int damage = currentWeapon.weaponDamage;

        if (other.gameObject.tag == "RockResource")
        {
            damage = damage * 2;

            if (other.TryGetComponent<EnemyHealth>(out var Health))
            {

                Health.objHealth = Health.objHealth - damage;

            }
        }

    }
}
