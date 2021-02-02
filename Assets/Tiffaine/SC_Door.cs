using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Door : MonoBehaviour
{
    [SerializeField]
    AudioSource SoundBrancheBreak;

    bool alreadyActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            if (alreadyActivate == false)
            {
                Destroy(other.gameObject);
                transform.gameObject.SetActive(false);
                SoundBrancheBreak.Play();
                alreadyActivate = true;
            }

        }
    }




}
