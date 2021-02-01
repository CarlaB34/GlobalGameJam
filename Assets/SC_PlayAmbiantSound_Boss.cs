using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayAmbiantSound_Boss : MonoBehaviour
{
    [SerializeField]
    AudioSource MusicBoss;
    [SerializeField]
    SC_PlayAmbiantSound MusicBase;

    bool alreadyPlayed;

    private void OnTriggerEnter(Collider other)
    {
        MusicBase.Music.Stop();


        if (other.tag == "Player" && alreadyPlayed == false)
        {

            MusicBoss = GetComponent<AudioSource>();
            MusicBoss.Play(0);
            alreadyPlayed = true;

        }


    }




}
