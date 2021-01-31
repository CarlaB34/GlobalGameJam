using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyStats : ScriptableObject
{
    public int MaxHp;
    public int HP;
    public int Damages;
    public int enemy_index;
}
