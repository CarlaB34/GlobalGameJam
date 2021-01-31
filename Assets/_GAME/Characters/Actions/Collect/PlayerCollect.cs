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


    private void Awake()
    {
        m_detection = GetComponent<CollectibleDetection>();
    }


    public void OnInteract()
    {
        if (m_detection.HasActionnableInRange())
        {
            if (CollectibleController.HasObject)
            {
                if (boss.GetComponent<BossDetection>().HasActionnableInRange())
                {
                    timer = 0;
                    GlobalVars.NbCollectibles--;
                    Debug.Log("Give");
                    boss.GetComponent<BossDetection>().DecreaseRange(2);
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
        if (timer < CD)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if(!CollectibleController.HasObject)
                EnemyShoot.IsShotEnabled = true;
        }
    }



}
