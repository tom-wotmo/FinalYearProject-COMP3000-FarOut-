using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCombatScript : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the activating of the health bars on combat
    //
    //
    //
    //
    [SerializeField] private GameObject healthBar;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthBar.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthBar.SetActive(false);
        }
    }


}
