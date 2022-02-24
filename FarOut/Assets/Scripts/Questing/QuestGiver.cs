using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class QuestGiver : MonoBehaviour
{
    private InputDevice targetDevice;
    [SerializeField]private Quest quest;
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject questWindow;
    [SerializeField] private Text questTitle, questDescription;
    private List<string> questItemTag = new List<string>();
    private List<GameObject> QuestItems = new List<GameObject>();
    string p = "Player";
    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

    }
    private void Update()
    {
        questTitle.text = quest.GetTitle();
        questDescription.text = quest.GetDescription();

        questItemTag = quest.GetItemTags();

        foreach (var item in questItemTag)
        {
            Debug.Log(item);
        }
    }
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        questTitle.text = quest.GetTitle();
        questDescription.text = quest.GetDescription();

    }
    public void CloseQuestWindow() 
    {
        questWindow.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (other.gameObject.tag == p && primaryButtonValue)
        {
            OpenQuestWindow();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (other.gameObject.tag == p || primaryButtonValue)
        {
            CloseQuestWindow();
        }
    }
    public void QuestCompletion()
    {
        
    }






}
