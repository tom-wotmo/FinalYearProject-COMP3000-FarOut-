using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PickUpObject : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the picking up of objects for quests.
    //
    //
    //
    //
   
    [SerializeField] private GameObject deSpawnFX;
    [SerializeField] private AudioSource deSpawnAudio;
    [SerializeField] private GameObject UITooltip;
    [SerializeField] private GameObject thisObject; // this is because sometimes we're destroying the parent of the object for animations sake
  
    private SkinnedMeshRenderer thisMesh;
    private string p = "Player";

    public void PickUpThisObject()
    {
        thisMesh = GetComponent<SkinnedMeshRenderer>();

        Destroy(UITooltip);

        thisMesh.enabled = !thisMesh.enabled;

        Instantiate(deSpawnFX, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3f, gameObject.transform.position.z), Quaternion.identity);

        deSpawnAudio.Play();

        Destroy(thisObject, 3f);
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == p && gameObject.activeSelf)
        {
            UITooltip.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == p && gameObject.activeSelf)
        {
            UITooltip.SetActive(false);
        }
    }

}
