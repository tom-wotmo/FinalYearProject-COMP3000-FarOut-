using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/EnemyStats")]
public class NewEnemy : ScriptableObject
{
    public string enemyName = "";
    public int amountToRegen = 0;
    public int timeToRegenSeconds = 0;

}