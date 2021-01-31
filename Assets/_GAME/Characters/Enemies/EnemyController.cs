﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;

    private void Awake()
    {
        stats.HP = stats.MaxHp;
    }

    public void Damage(int amount)
    {
        stats.HP -= amount;

        Debug.Log(stats.HP);

        if (stats.HP <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }
}