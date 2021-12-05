using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int objHealth = 100;
     void Start()
    {
        StartCoroutine(RejenerateHealth());
    }
    IEnumerator RejenerateHealth()
    {
        while (true)
        {
            if (objHealth < 100)
            {
                objHealth += 1;
                yield return new WaitForSeconds(1);
            }
            else { yield return true; }
        }
    }

}
