using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedQuest : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the data of the quests
    //
    //
    //
    //
    [SerializeField] private bool isQuestActive = false;
    [SerializeField] private string title;
    [SerializeField] private string description,completedDescription;
    [SerializeField] private bool completed;
    [SerializeField] private List<GameObject> questItem = new List<GameObject>();
    [SerializeField] private GameObject questReward;

    public void Update()
    {
        ClearEmpty();
        QuestCompletion();
    }
    //
    // checks to see if the list of items in the quest is empty, e.g. the given quests have had their npc's killed or the items picked up at which point they're destroyed
    //
    private void QuestCompletion()
    {
        if (questItem.Count.Equals(0))
        {
            completed = true;
        }
    }
    //
    //removes any blank game objects from the list when it gets deleted from the list
    //
    private void ClearEmpty()
    {
        for(var i = questItem.Count - 1; i > -1; i--)
        {
            if (questItem[i] == null)
                questItem.RemoveAt(i);
        }
    } 
    //
    //getters and setters
    //
    public string GetTitle()
    {return title;}
    public string GetDescription()
    {return description;}
    public string GetCompletedDescription()
    { return completedDescription;}
    public bool getComplete()
    {return completed;}
    public bool getIsQuestActive()
    {return isQuestActive;}
    public void setActive(bool c)
    {isQuestActive = c;}
    public List<GameObject> GetQuestItems()
    { return questItem;}
    public GameObject GetReward() 
    { return questReward;}
}
