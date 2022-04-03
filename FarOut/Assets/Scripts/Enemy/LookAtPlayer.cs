using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    //
    //
    //apply this script to any object you want to look toward the player e.g npcs or enemies
    //
    //
    [SerializeField]private GameObject player;
    [SerializeField]private LayerMask WhatIsPlayer;
    [SerializeField]private float sightRange;
    [SerializeField]private bool playerInSightRange;
    private void Update()
    {
        lookAtPlayer();
    }
    void lookAtPlayer()
    {
        Vector3 playerTransform = new Vector3(gameObject.transform.position.x, player.transform.position.y , player.transform.position.z);
        transform.LookAt(playerTransform);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, sightRange);
    }
}
