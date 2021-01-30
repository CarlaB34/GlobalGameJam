using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltereDetectState : State
{
    private Player m_Player;
    private float m_DistanceOneRange;
    private float m_DistanceTwoRange;
    public AltereDetectState(Player p_Player, float m_Distance)
    {
         m_Player = p_Player;
    }

    public override void OnStateUpdate(FSM p_FSM, GameObject p_Obj, float p_DeltaTime)
    {
        if (Vector3.Distance(p_Obj.transform.position, m_Player.transform.position) < m_DistanceOneRange)
        {
            Debug.Log("dist 1");
           

          
        }


        //si j'entre dans ma deuxieme range
        if (Vector3.Distance(p_Obj.transform.position, m_Player.transform.position) < m_DistanceTwoRange)
        {

            Debug.Log("enter 2 range");
          //  Debug.Log(m_DistanceSecur);
          //  Debug.Log(m_DistanceSecur);
        }
    }
}
