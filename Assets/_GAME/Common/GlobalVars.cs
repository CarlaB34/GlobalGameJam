using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static int PlayerHPMax = 100;
    public static int PlayerHP = 100;
    public static int PlayerDamages = 10;

    public static int NbCollectibles = 0;
    public static int NbCollectiblesMax = 0;

    public static int playerHPCurrent;
    private void Awake()
    {
        NbCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        playerHPCurrent = PlayerHP;
        NbCollectibles = NbCollectiblesMax;

        
    }

    private void Update()
    {

        Debug.Log("Collectibles: " + NbCollectibles);
    }
}
