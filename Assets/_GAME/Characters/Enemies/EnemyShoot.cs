using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float force = 5f;

    [SerializeField]
    private float fireRate = 5f;
    private float nextFire;
    private Vector3 playerPos = Vector3.zero;

    private void Update()
    {

        RaycastHit hit;



        
        if (boss.GetComponent<BossDetection>().IsInRange & Physics.Raycast(fire.transform.position,player.transform.position,out hit))
        {
            if(playerPos == Vector3.zero && Time.time > nextFire)
            {
                nextFire += fireRate;
                playerPos = player.transform.position;
                GameObject proj = Instantiate(projectile, fire.transform.position, Quaternion.identity);
                proj.GetComponent<Rigidbody>().AddForce(boss.transform.forward * force, ForceMode.VelocityChange);
                playerPos = Vector3.zero;
            }
        }
    }

    
}

