using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollect : MonoBehaviour
{

    private CollectibleDetection m_detection;
    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private float CD = 15f;
    private float timer;

    public SO_Collectible[] list;

    public static string CurrentItem;

    [SerializeField]
    AudioSource Cadre_Audio;
    [SerializeField]
    AudioSource Moon_Audio;
    [SerializeField]
    AudioSource Livre_Audio;
    [SerializeField]
    AudioSource Corde_Audio;




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

                        switch (CurrentItem)
                        {
                            case "Cadre":
                                Cadre_Audio.Play();
                                break;
                            case "corde":
                                Corde_Audio.Play();
                                break;
                            case "livre":
                                Livre_Audio.Play();
                                break;
                            case "lune":
                                Moon_Audio.Play();
                                break;

                        }


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

        if (GlobalVars.NbCollectibles == -4)
        {
            win();
        }
        Debug.Log(GlobalVars.NbCollectibles);
        
    }

    public void win()
    {
        Debug.Log("win");
        StartCoroutine(winScreen());
    }

    IEnumerator winScreen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuEndChoice");
       Debug.Log("Victoire");
    }
    
}
