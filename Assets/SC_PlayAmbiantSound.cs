using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayAmbiantSound : MonoBehaviour
{
    private static SC_PlayAmbiantSound instance = null;
    public AudioSource Music;

    private void Awake()
    {

    }

    void Start()
    {
        //Music = GetComponent<AudioSource>();
        Music.Play();
    }
}
