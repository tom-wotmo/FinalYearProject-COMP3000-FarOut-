using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Objects/ObjectStats")]
public class NewObject : ScriptableObject
{
    public string objectName = "";
    public int amountToRegen = 0;
    public int timeToRegenSeconds = 0;


}
