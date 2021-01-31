using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField]
    private UnityEvent m_Animaiton = new UnityEvent();

    private void Awake()
    {
        stats.HP = stats.MaxHp;
        m_Animaiton.Invoke();
    }

    public void Damage(int amount)
    {
        stats.HP -= amount;
    }
}
