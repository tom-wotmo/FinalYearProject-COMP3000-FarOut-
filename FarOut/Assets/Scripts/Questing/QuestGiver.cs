using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class QuestGiver : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the npc that gives out quests
    //
    //
    //
    //

    private InputDevice targetDevice;
    [SerializeField] private ScriptedQuest quest;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject questWindow;
    [SerializeField] private Text questTitle, questDescription;
    [SerializeField] private GameObject questMarkerInitial, questMarkerCompleted;
    [SerializeField] private GameObject acceptButton, completeButton;
    [SerializeField] private GameObject environmentObjectsOld, environmentObjectsNew;
    private bool questAccepted = false;
    bool loopBool = true;
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
        questMarkerCheck();
    }
    private void Update()
    {
        QuestCompletion();
        questMarkerDeactivate();
    }
    //
    //opens the quest window
    //
    public void OpenQuestWindow()
    {
        quest.setActive(true);
        questWindow.SetActive(true);
        questTitle.text = quest.GetTitle();
        questDescription.text = quest.GetDescription();
    }
    //
    //closes the quest window
    //
    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }
    //
    //used to update the world objects
    //
    public void WorldChange()
    {
        environmentObjectsOld.SetActive(false);
        environmentObjectsNew.SetActive(true);
    }
    public void buttonPickUpQuest()
    {
        questAccepted = true;

        //do other fancy stuff
    }
    //
    //action behind the quest button hand in
    //
    public void buttonQuestHandIn()
    {
        GameObject reward = quest.GetReward();
        Instantiate(reward, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 2), Quaternion.identity);
        Destroy(questWindow);
        Destroy(gameObject.GetComponent<ScriptedQuest>());
        Destroy(gameObject.GetComponent<QuestGiver>());
        Destroy(questMarkerCompleted);
    }
    //
    //opens the quest window when in range and or button is pressed
    //
    public void OnTriggerEnter(Collider other)
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (other.gameObject.tag == p/* && primaryButtonValue*/)
        {
            OpenQuestWindow();
        }
    }
    //
    //closes the quest window when in range and or button is pressed
    //
    public void OnTriggerExit(Collider other)
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (other.gameObject.tag == p || primaryButtonValue)
        {
            CloseQuestWindow();
        }
    }
    //
    //checks to see if the NPC has a quest active to enable the UI above their head
    //
    public void questMarkerCheck()
    {
        if(this.gameObject.GetComponent<ScriptedQuest>().isActiveAndEnabled == true)
        {
            questMarkerInitial.SetActive(true);
        }
    }
    //
    //deactivates the quest marker 
    //
    public void questMarkerDeactivate()
    {
        if (questAccepted && loopBool)
        {
            Destroy(questMarkerInitial);
            questWindow.SetActive(false);
            Destroy(acceptButton);
            loopBool = false;
        }
    }
    //
    //
    //
    public void QuestCompletion()
    {
        bool completion = quest.getComplete();
        bool questActive = quest.getIsQuestActive();

        if (completion && questActive)
        {
            questMarkerCompleted.SetActive(true);
            questWindow.SetActive(true);
            completeButton.SetActive(true);
            questDescription.text = quest.GetCompletedDescription();
        }
    }






}
