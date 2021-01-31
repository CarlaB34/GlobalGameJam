using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAttack>().Damage(boss.GetComponent<EnemyController>().stats.Damages);
        }        
    }
}
