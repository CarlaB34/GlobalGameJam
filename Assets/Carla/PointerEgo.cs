using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEgo : MonoBehaviour
{

    //[SerializeField]
    //private Vector3 m_DirCompass;

    [SerializeField]
    private Transform m_Player;
    [SerializeField]
    private Transform m_Compass;
    private float m_TurnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 l_Target = m_Player.position - transform.position;
        float l_AngleTarget = Vector3.Angle(m_Compass.transform.forward, l_Target);
        Vector3 l_TurnAxis = Vector3.Cross(m_Compass.transform.position, l_Target);

        transform.RotateAround(m_Compass.transform.position, l_TurnAxis, Time.deltaTime * m_TurnRate * l_AngleTarget);
    }
}
