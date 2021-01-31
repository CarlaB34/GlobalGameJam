using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;

    [SerializeField]
    AudioSource SoundBrancheBreak;

    [SerializeField]
    AudioSource SoundBrancheHit;

    private void Awake()
    {
        stats.HP = stats.MaxHp;
    }

    public void Damage(int amount)
    {
        stats.HP -= amount;


        if (stats.enemy_index == 0)
        {
            SoundBrancheHit.Play();
        }
        else
        {
            //ici son ennemi hitted
        }

        if (stats.HP <= 0)
        {
            if (stats.enemy_index == 0)
            {
                SoundBrancheBreak.Play();
            }
            else
            {
                //ici son ennemi mort
            }


        }
    }
}
