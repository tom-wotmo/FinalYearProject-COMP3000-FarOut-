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
    public void ObjectDeath()
    {
        //different deaths for different objects, 
        if(gameObject.tag == "WoodResource") 
        {
            if (currObjHealth <= minHp && objDeathBool)
            {
                Object.Destroy(gameObject, 3f);

                StartCoroutine(DeadPrefab(2.80f));

                Animator treeAnimator = GetComponent<Animator>();
                treeAnimator.SetTrigger("isCollapse");

                objDeathBool = false;

               // GetComponent<BoxCollider>().
            }
        }
        if(gameObject.tag == "RockResource")
        {
            if(currObjHealth <= minHp)
            {
                StartCoroutine(DeadPrefab(0f));

                Object.Destroy(gameObject, 0.5f);


            }
        }
 
    }
    //spawns some rubble or a stump to show where the player has destroyed stuff

    IEnumerator DeadPrefab(float secondsToSpawn)
    {
        yield return new WaitForSeconds(secondsToSpawn);

        yield return Instantiate(objectPrefabLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

}
