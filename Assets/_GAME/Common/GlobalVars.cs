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

    private void Awake()
    {
        NbCollectiblesMax = GameObject.FindGameObjectsWithTag("FinalCollectible").Length;
        NbCollectibles = NbCollectiblesMax;

        
    }

    private void Update()
    {

        Debug.Log("Collectibles: " + NbCollectibles);
    }
}
