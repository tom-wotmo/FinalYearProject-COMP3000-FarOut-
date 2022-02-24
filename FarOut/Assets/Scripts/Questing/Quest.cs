using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quest/QuestFrame")]
[System.Serializable]
public class Quest : ScriptableObject
{
    [SerializeField] private bool isQuestActive = false;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private bool completed;
    [SerializeField] private List<string> itemTag = new List<string>();
    [SerializeField] private List<GameObject> questItem = new List<GameObject>();
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
    public List<string> GetItemTags()
    {
        return itemTag;
    }
    public List<GameObject> GetQuestItems()
    {
        return questItem;
    }


}