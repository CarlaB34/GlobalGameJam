using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAltere : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 5;
    [SerializeField]
    private Transform[] m_PointPatrol = { };

    private Vector3 m_Target;
    private float m_DistancePoint = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Target = m_PointPatrol[Random.Range(0, m_PointPatrol.Length)].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, m_Target)<  m_DistancePoint)
        {
            m_Target = m_PointPatrol[Random.Range(0, m_PointPatrol.Length)].position;
        }

        Vector3 toTarget = m_Target - transform.position;
        toTarget.Normalize();
       transform.position += toTarget * m_Speed * Time.deltaTime;
    }
}
