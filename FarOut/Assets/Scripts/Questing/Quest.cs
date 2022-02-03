using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isQuestActive;

    [SerializeField]private string title;
    [SerializeField]private string description;
    [SerializeField]private int experience;
    [SerializeField]private int goldReward;

    public string GetTitle()
    {
        return title;
    }
    public string GetDescription()
    {
        return description;
    }
    public int GetExperience()
    {
        return experience;
    }
    public int GetGoldReward()
    {
        return goldReward;
    }
}