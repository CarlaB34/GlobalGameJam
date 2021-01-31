using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
            transform.gameObject.SetActive(false);

        }
    }




}
