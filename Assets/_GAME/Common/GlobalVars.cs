﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static int PlayerHPMax = 100;
    public static int PlayerHP = 100;
    public static int PlayerDamages = 10;

    public static int NbCollectibles;

    private void Awake()
    {
        NbCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        
    }

    private void Update()
    {

        Debug.Log("Collectibles: " + NbCollectibles);
    }
}
