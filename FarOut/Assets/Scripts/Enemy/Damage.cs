using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    float objecthealth = 100f;
    float swordDamage = 10f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon") 
        {
            objecthealth = objecthealth - swordDamage;

            Debug.Log(objecthealth);
        }
        if (objecthealth == 0f)
        {
            this.gameObject.SetActive(false);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
