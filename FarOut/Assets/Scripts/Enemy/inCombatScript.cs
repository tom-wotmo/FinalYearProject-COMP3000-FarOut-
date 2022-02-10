using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCombatScript : MonoBehaviour
{
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
