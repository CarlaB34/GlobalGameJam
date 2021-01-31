using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TtalkEnemy : MonoBehaviour
{
    [SerializeField]
    AudioSource NeedMoon;
    [SerializeField]
    AudioSource NeedBook;
    [SerializeField]
    AudioSource NeedCanvas;
    [SerializeField]
    AudioSource NeedRope;


    private bool m_isTalck = false;
    private float m_TimeTalk = 2f;
    public bool Talk
    {
        get { return m_isTalck; }
        set { m_isTalck = value; }
    }

    private void Update()
    {
        if(m_isTalck == true)
        {
            m_TimeTalk -= Time.deltaTime;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (PlayerCollect.CurrentItem == "lune")
        {
            NeedMoon.Play();
        }
        else if (PlayerCollect.CurrentItem == "corde")
        {
            NeedRope.Play();
        }
        else if (PlayerCollect.CurrentItem == "livre")
        {
            NeedBook.Play();
        }
        else if (PlayerCollect.CurrentItem == "Cadre")
        {
            NeedCanvas.Play();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        m_isTalck = true;
       if (PlayerCollect.CurrentItem == "Cadre")
        {
            Debug.Log("coucou");
            NeedCanvas.Play();
        }
    }
}
