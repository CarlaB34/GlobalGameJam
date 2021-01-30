using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEgo : MonoBehaviour
{
    [SerializeField, Min(.05f)]
    [Tooltip("Defines how far this entity can detect objects")]
    private float m_SightSecondRange = 8f;
    //[SerializeField]
    //private Vector3 m_DirCompass;

    [SerializeField]
    private Transform m_Player;

    [SerializeField]
    private Transform m_Sprite;

    private WaitForSeconds m_ShootDuration = new WaitForSeconds(.07f);
   
 
    // Start is called before the first frame update
    void Start()
    {
        m_Sprite.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(m_Player.transform.position, transform.position)< m_SightSecondRange)
        {
            m_Sprite.gameObject.SetActive(true);
            transform.LookAt(m_Player.transform.position);
        }
        else
        {
            m_Sprite.gameObject.SetActive(false);
        }
    }
}
