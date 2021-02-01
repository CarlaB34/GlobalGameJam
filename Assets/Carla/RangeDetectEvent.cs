using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RangeDetectEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_OnJump = new UnityEvent();
    private Player m_Player = null;
    private float m_DistanceOneRange = 0f;
    private float m_DistanceTwoRange = 0f;

    [SerializeField]
    private GameObject m_Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(m_Object.transform.position, m_Player.transform.position) < m_DistanceOneRange)
        {
            m_OnJump.Invoke();
        }
    }
}
