using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{

    private CollectibleDetection m_detection;
    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private float CD = 15f;
    private float timer;

    public SO_Collectible[] list;

    private string CurrentItem { get; set;}

    private void Awake()
    {
        m_detection = GetComponent<CollectibleDetection>();
        CurrentItem = list[0].name;
    }

    public void OnInteract()
    {
        if (m_detection.HasActionnableInRange())
        {
            if (CollectibleController.HasObject)
            {
                if (boss.GetComponent<BossDetection>().HasActionnableInRange())
                {
                    if(m_detection.GetActionnableInRange().GetComponent<CollectibleController>().Info.name == CurrentItem)
                    {
                        Debug.Log("Give");
                        GlobalVars.NbCollectibles--;
                        boss.GetComponent<BossDetection>().DecreaseRange(4);
                        System.Random rand = new System.Random();
                        int i = rand.Next(0, 4);
                        CurrentItem = list[i].name;
                    }
                    else
                    {
                        GlobalVars.NbCollectibles++;
                        boss.GetComponent<BossDetection>().DecreaseRange(-4);
                    }
                    timer = 0;
                    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("FinalCollectible"))
                    {
                        obj.GetComponent<Renderer>().enabled = true;
                    }
                    
                    Destroy(m_detection.GetActionnableInRange());
                }
                else
                {
                    EnemyShoot.IsShotEnabled = true;
                }                
            }
            m_detection.GetActionnableInRange().GetComponent<CollectibleController>().Collect();
            
        }
    }

    private void Update()
    {
        Debug.Log("name:" + CurrentItem);
        if (timer < CD)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if(!CollectibleController.HasObject)
                EnemyShoot.IsShotEnabled = true;
        }

        if(GlobalVars.NbCollectibles <= 0)
        {
            win();
        }
    }

    public static void win()
    {
        Debug.Log("Victoire");
    }
}
