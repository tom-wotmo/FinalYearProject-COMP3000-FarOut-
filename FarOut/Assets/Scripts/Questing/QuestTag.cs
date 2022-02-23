using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTag : MonoBehaviour
{
    [SerializeField]private string questTag;

    public string getQuestTag()
    {
        return questTag;
    }

}
