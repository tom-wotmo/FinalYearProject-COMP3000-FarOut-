using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponDamage : MonoBehaviour
{
    public Weapons currentWeapon;
    [SerializeField]private GameObject floatDamage;
    private Camera playerCamera;

 
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

                    Health.objHealth = Health.objHealth - damage;

                    GameObject damagePoints = Instantiate(floatDamage, transform.position, camView) as GameObject;

                    damagePoints.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();

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

                    GameObject damagePoints = Instantiate(floatDamage, transform.position, camView) as GameObject;

                    damagePoints.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();

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

                    //Vector3 dmgPos = new Vector3(transform.position.x, transform.position.y, -3.0f);

                    GameObject damagePoints = Instantiate(floatDamage, transform.position, camView) as GameObject;

                    damagePoints.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();

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
