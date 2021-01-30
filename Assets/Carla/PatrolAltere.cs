using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAltere : State
{

    private const float ARRIVAL_DISTANCE = 0.5f;
    private Transform[] m_PatrolPoints = { };
    private float m_MovementSpeed = 0f;

    private Vector3 m_CurrentTarget = Vector3.zero;

    public PatrolAltere(Transform[] _PatrolPoints, float _MovementSpeed)
    {
        m_PatrolPoints = _PatrolPoints;
        m_MovementSpeed = _MovementSpeed;
    }

    public override void OnStateEnter(FSM p_FSM, GameObject p_Obj)
    {
        Debug.Log("ENTER " + nameof(PatrolAltere));
        m_CurrentTarget = m_PatrolPoints[Random.Range(0, m_PatrolPoints.Length)].position;
    }

    public override void OnStateUpdate(FSM p_FSM, GameObject p_Obj, float p_DeltaTime)
    {
        if (Vector3.Distance(p_Obj.transform.position, m_CurrentTarget) <= ARRIVAL_DISTANCE)
        {
            m_CurrentTarget = m_PatrolPoints[Random.Range(0, m_PatrolPoints.Length)].position;
        }

        Vector3 toTarget = m_CurrentTarget - p_Obj.transform.position;
        toTarget.Normalize();
        p_Obj.transform.position += toTarget * m_MovementSpeed * p_DeltaTime;
    }


}
