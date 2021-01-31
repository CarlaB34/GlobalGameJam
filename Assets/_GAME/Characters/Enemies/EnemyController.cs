using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField]
    private UnityEvent m_Animaiton = new UnityEvent();

    [SerializeField]
    AudioSource SoundBrancheBreak;

    [SerializeField]
    AudioSource SoundBrancheHit;

    private bool isDeath = false;
    public bool IsDie
    {
        get { return isDeath; }
        set { isDeath = value; }
    }
    private void Awake()
    {
        stats.HP = stats.MaxHp;
        m_Animaiton.Invoke();
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


        if(stats.HP <=0)
        {
            isDeath = true;
        }
    }
}
