using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int currObjHealth;
    public int MaxObjHealth;
    private int minHp = 0;
    public GameObject objectPrefabLeft;
    public NewObject NewObject;
    bool objDeathBool = true;
    void Start()
    {
    
        StartCoroutine(RejenerateHealth());


    }
    private void Update()
    {
        ObjectDeath();
    }
    IEnumerator RejenerateHealth()
    {
        int regen = NewObject.amountToRegen;

        int time = NewObject.timeToRegenSeconds;

        while (true)
        {
            if (currObjHealth < MaxObjHealth)
            {
                currObjHealth += regen;
                yield return new WaitForSeconds(time);
            }
            else { yield return true; }
        }
    }
    void ObjectDeath()
    {
        //different deaths for different objects, 
        if(gameObject.tag == "WoodResource") 
        {
            if (currObjHealth <= minHp && objDeathBool)
            {
                Object.Destroy(gameObject, 3f);

                StartCoroutine(DeadPrefab());

                Animator treeAnimator = GetComponent<Animator>();
                treeAnimator.SetTrigger("isCollapse");

                objDeathBool = false;
            }
        }
        if(gameObject.tag == "RockResource")
        {
            if(currObjHealth <= minHp)
            {
                Object.Destroy(gameObject);
            }
        }
 
    }
    //spawns some rubble or a stump to show where the player has destroyed stuff

    IEnumerator DeadPrefab()
    {
        yield return new WaitForSeconds(2.80f);

        yield return Instantiate(objectPrefabLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

}
