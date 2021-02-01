using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayNarration : MonoBehaviour
{
    [SerializeField]
    AudioSource Voix;

    bool alreadyPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && alreadyPlayed == false)
        {
            Voix = GetComponent<AudioSource>();
            Voix.Play(0);
            alreadyPlayed = true;
        }
    }


}
