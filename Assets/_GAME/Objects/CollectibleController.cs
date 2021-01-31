using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{

    public Transform Player;
    [SerializeField]
    private GameObject prefab;

    public static bool HasObject;

    [SerializeField]
    private float CD = 15f;
    private float timer;

    private void Awake()
    {
        timer = CD;
    }
    public void Collect()
    {
        if (HasObject == false)
        {
            GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity);
            clone.transform.parent = Player;
            HasObject = true;
            EnemyShoot.IsShotEnabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            timer = 0;
        }

        else
        {
            this.transform.parent = null;
            HasObject = false;
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        Debug.Log(HasObject);
        if (timer < CD)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (gameObject.GetComponent<Renderer>().enabled == false)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }
        public void Colect()
        {
            GlobalVars.NbCollectibles--;
            Destroy(gameObject);
        }
    
}
