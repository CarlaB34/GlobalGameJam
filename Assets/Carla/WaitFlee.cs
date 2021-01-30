using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFlee : State
{
    private float m_WaitDuration = 2f;

    private float m_Timer = 0f;
    private Vector3 m_DirectionFlee;
    private Player m_Player;
    public WaitFlee(float p_WaitDuration, Vector3 p_DirectionFlee, Player p_Player)
    {
        m_WaitDuration = p_WaitDuration;
        m_DirectionFlee = p_DirectionFlee;
        m_Player = p_Player;
    }

    public override void OnStateEnter(FSM p_FSM, GameObject p_Obj)
    {
        m_Timer = 2f;
    }

    public override void OnStateUpdate(FSM p_FSM, GameObject p_Obj, float p_DeltaTime)
    {
        AlterEntity l_Entity = p_Obj.GetComponent<AlterEntity>();
        m_Timer -= p_DeltaTime;
        if(0 <m_Timer )
        {
            m_DirectionFlee = p_Obj.transform.position - m_Player.transform.position;
            p_Obj.transform.Translate(m_DirectionFlee * l_Entity.Speed * Time.deltaTime);
            p_FSM.SetParameter("WaitFlee", true);
        }
        if(m_Timer < 0)
        {
            m_Timer = 0;
            p_FSM.SetParameter("WaitFlee", false);
        }
    }
}
