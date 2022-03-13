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

    private InputDevice targetDevice;
    [SerializeField] private GameObject player;
    private string p = "Player";

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(p);
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (other.gameObject.tag == p && primaryButtonValue)
        {
            Destroy(gameObject);
        }
    }

}
