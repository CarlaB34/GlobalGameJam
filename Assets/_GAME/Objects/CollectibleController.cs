using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public SO_Collectible Info;

    public Transform Player;
    [SerializeField]
    private GameObject prefab;

    public static bool HasObject;

    [SerializeField]
    private float CD = 15f;
    private float timer;
    private bool CDOn = false;

    [SerializeField]
    AudioSource Takeitem_Sound;

    private void Awake()
    {
        timer = CD;
    }
    public void Collect()
    {
        if (HasObject == false)
        {
            if(gameObject.tag == "FinalCollectible")
            {
                GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity);
                clone.tag = "Clone";
                clone.transform.parent = Player;
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                transform.parent = Player;
            }          
            HasObject = true;
            EnemyShoot.IsShotEnabled = false;
        }

        else
        {
            this.transform.parent = null;
            HasObject = false;
            transform.parent = null;
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

            if (CDOn)
            {
                CDOn = false;
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
