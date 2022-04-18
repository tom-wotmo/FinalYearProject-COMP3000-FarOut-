using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Objects/ObjectStats")]
public class NewObject : ScriptableObject
{
    //
    //
    //
    //
    //----- script to control the object creation
    //
    //
    //
    //
    [SerializeField]private string objectName = "";
    [SerializeField]public int amountToRegen = 0;
    [SerializeField]public int timeToRegenSeconds = 0;

    public string getObjectName()
    { return objectName; }
    public int getAmountToRegen()
    { return amountToRegen; }
    public int getTimeToRegendSeconds()
    { return timeToRegenSeconds; }
    

}
