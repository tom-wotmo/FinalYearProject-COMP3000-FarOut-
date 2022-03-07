using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitFx : MonoBehaviour
{

    [SerializeField]private GameObject objHitFx;
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        CreateFX(pos, rot);

    }

    private void CreateFX(Vector3 pos, Quaternion rot)
    {
        GameObject FX = Instantiate(objHitFx, pos, rot);
        FX.transform.parent = gameObject.transform;

        Destroy(FX, 2);
    }
}
