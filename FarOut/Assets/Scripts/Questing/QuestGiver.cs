using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject player;
    public GameObject questWindow;
    public Text questTitle, questDescription, questReward;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);

        questTitle.text = quest.GetTitle();
        questDescription.text = quest.GetDescription();
        questReward.text = quest.GetGoldReward().ToString();


    }


    
}
