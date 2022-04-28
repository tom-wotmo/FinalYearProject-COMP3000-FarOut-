using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponDamage : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the damage of the weapons
    //
    //
    //
    //
    public Weapons currentWeapon;
    [SerializeField]private GameObject floatDamage;
    private Camera playerCamera;
    [SerializeField]private AudioSource woodHitSound, rockHitSound;

    private void OnTriggerEnter(Collider other)
    {
        playerCamera = Camera.main;
        Quaternion camView = playerCamera.transform.rotation;
        int damage = currentWeapon.weaponDamage;

        if (currentWeapon.DamageWeapon == true)
        {
            if (other.gameObject.tag == "Humanoid")
            {

                if (other.TryGetComponent<EnemyHealth>(out var Health))
                {
                    DamageIntegerInstans(camView, damage);
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
                    DamageIntegerInstans(camView, damage);

                    Health.currObjHealth = Health.currObjHealth - damage;
                    //play the sound on successful hit
                    rockHitSound.Play();
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
                    DamageIntegerInstans(camView, damage);

                    Health.currObjHealth = Health.currObjHealth - damage;
                    //play the sound on successful hit
                    woodHitSound.Play();
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
    public void DamageIntegerInstans(Quaternion iCamView, int iDamage) 
    {
        if (!floatDamage.scene.IsValid()) 
        {
            GameObject damagePoints = Instantiate(floatDamage, transform.position, iCamView) as GameObject;

            damagePoints.transform.GetChild(0).GetComponent<TextMesh>().text = iDamage.ToString();
        }
   
    }

}
