using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHit : MonoBehaviour
{
    public GameObject rockHitFX;
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        CreateFX(pos, rot);
       
    }

    private void CreateFX(Vector3 pos, Quaternion rot)
    {
        GameObject FX = Instantiate(rockHitFX, pos, rot);
        FX.transform.parent = gameObject.transform;

        Destroy(FX, 2);
    }

}
