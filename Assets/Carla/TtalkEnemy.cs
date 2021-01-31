using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TtalkEnemy : MonoBehaviour
{
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
        Debug.Log("firstphrase");
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinalCollectible")
        {
            //audio
            Debug.Log("parler");
            m_isTalck = true;
        }
        m_isTalck = false;
    }
}
