using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltereAttack : State
{

    private Player m_Player = null;
    private float m_MovementSpeed = 0f;

    public AltereAttack(Player p_PlayerRef, float p_MovementSpeed)
    {
        m_Player = p_PlayerRef;
        m_MovementSpeed = p_MovementSpeed;
    }

}
