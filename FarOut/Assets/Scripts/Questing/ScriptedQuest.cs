using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedQuest : MonoBehaviour
{
    [SerializeField] private bool isQuestActive = false;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private bool completed;
    [SerializeField] public List<GameObject> questItem = new List<GameObject>();
    public void Update()
    {
        ClearEmpty();
        QuestCompletion();

    }

    private void QuestCompletion()
    {
        if (questItem.Count.Equals(0))
        {
            completed = true;
        }
    }
    private void ClearEmpty()
    {
        for(var i = questItem.Count - 1; i > -1; i--)
        {
            if (questItem[i] == null)
                questItem.RemoveAt(i);
        }
    }
    private void QuestHandIn()
    {

    }
    public string GetTitle()
    {
        return title;
    }
    public string GetDescription()
    {
        return description;
    }
    public bool getComplete()
    {
        return completed;
    }
    public bool getIsQuestActive()
    {
        return isQuestActive;
    }
    public List<GameObject> GetQuestItems()
    {
        return questItem;
    }
}
