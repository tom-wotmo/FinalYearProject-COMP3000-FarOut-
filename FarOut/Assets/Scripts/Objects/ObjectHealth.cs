using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int objHealth = 100;
    public NewObject NewObject;
    void Start()
    {
        StartCoroutine(RejenerateHealth());
    }
    IEnumerator RejenerateHealth()
    {
        int regen = NewObject.amountToRegen;

        int time = NewObject.timeToRegenSeconds;


        while (true)
        {
            if (objHealth < 100)
            {
                objHealth += regen;
                yield return new WaitForSeconds(time);
            }
            else { yield return true; }
        }
    }
    private void Update()
    {
        ObjectDeath();
    }
    void ObjectDeath()
    {
        if (objHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

}
