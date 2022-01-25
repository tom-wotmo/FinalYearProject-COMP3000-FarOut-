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
        if (currObjHealth <= minHp)
        {
            Object.Destroy(gameObject, 3f);

            StartCoroutine(DeadPrefab());

            if (this.gameObject.tag == "WoodResource")
            {
                Animator treeAnimator = GetComponent<Animator>();
                treeAnimator.SetTrigger("isCollapse");

            }

        }
      

    }
    IEnumerator DeadPrefab()
    {
        yield return new WaitForSeconds(1f);

        yield return Instantiate(objectPrefabLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

}
