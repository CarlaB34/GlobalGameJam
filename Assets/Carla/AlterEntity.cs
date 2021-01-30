using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterEntity : MonoBehaviour
{
    [SerializeField]
    private float m_PatrolSpeed = 2f;

    [SerializeField]
    private float m_AttackSpeed = 6f;

    [SerializeField]
    private Transform[] m_PatrolPoints = { };

    private List<GameObject> m_ObjtRamasserPassif = null;

    [SerializeField]
    private Player m_Player = null;

    [SerializeField]
    private float m_RangeDetect = 20f;

    private FSM m_FSM = null;

    private float m_Distance;

    private Vector3 m_Direction = Vector3.zero;

    public float Speed
    {
        get { return m_PatrolSpeed; }
        set { m_PatrolSpeed = value; }
    }
    private void Awake()
    {

        m_FSM.SetParameter("isPatrolling", false);
        m_FSM.SetParameter("seePlayer", false);
        m_FSM.SetParameter("AttackPlayer", false);
        m_FSM.SetParameter("PassificAttack", false);
        m_FSM.SetParameter("WaitFlee", false);

        State l_Patrol = new PatrolAltere(m_PatrolPoints, m_PatrolSpeed);
        State l_WaitFlee = new WaitFlee(2f, m_Direction, m_Player);
       // State l_Attack = new AltereAttack(m_Player, m_AttackSpeed);
        State l_AltereDetect = new AltereDetectState(m_Player, m_Distance);
        State l_PassificState = new PassificState(m_ObjtRamasserPassif);


        l_Patrol.AddTransition(l_WaitFlee, new TransitionCondition_CheckBool("seePlayer", true));
        l_WaitFlee.AddTransition(l_AltereDetect, new TransitionCondition_CheckBool("WaitFlee", false));
        l_AltereDetect.AddTransition(l_PassificState, new TransitionCondition_CheckBool("PassificAttack", true));
        l_PassificState.AddTransition(l_AltereDetect, new TransitionCondition_CheckBool("AttackPlayer", true));
        l_WaitFlee.AddTransition(l_Patrol, new TransitionCondition_CheckBool("isPatrolling", false));

        m_FSM.Initialization(l_Patrol);

        Debug.Log("Enemy current state : " + m_FSM.CurrentState);
    }

    private void Update()
    {
      //  m_FSM.SetParameter("seePlayer", Vector3.Distance(transform.position, m_Player.transform.position) <= m_SightRange);

        m_FSM.Update(Time.deltaTime, gameObject);

        //si ma distance entre ces deux point et inferieur a la distance alors je patrol
        if(Vector3.Distance(m_Player.transform.position, transform.position) < m_Distance)
        {
            m_FSM.SetParameter("isPatrolling", true);
        }
        //si elle est sup alors le joueur est dans la range
        if(Vector3.Distance(m_Player.transform.position, transform.position) > m_Distance)
        {
            m_FSM.SetParameter("isPatrolling", false);
            m_FSM.SetParameter("seePlayer", true);
        }

        
    }
}
