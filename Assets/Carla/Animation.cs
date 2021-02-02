using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement m_PlayerMove = null;
    [SerializeField]
    private GlobalVars m_Vars = null;
    [SerializeField]
    private Animator m_Anim;

    [SerializeField]
    private PlayerAttack m_PlayerAttack = null;

    private static readonly int m_SpeedAnimProperties = Animator.StringToHash("speed");
    private static readonly int m_PropertiesBoolShield = Animator.StringToHash("isShield");
    private static readonly int m_PropertiesBoolSAtack = Animator.StringToHash("isAttack");
    private static readonly int m_PropertiesBoolDeath = Animator.StringToHash("IsDiying");
    private static readonly int m_AnimPropertiesLife = Animator.StringToHash("life");
    private static readonly int m_AnimPropertiesDamages = Animator.StringToHash("IsDamage");




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        m_Anim.SetFloat(m_SpeedAnimProperties,m_PlayerMove.Speed);
       m_Anim.SetFloat(m_AnimPropertiesLife, GlobalVars.PlayerHP);        
       m_Anim.SetBool(m_PropertiesBoolShield, m_PlayerAttack.IsShielded);
       m_Anim.SetBool(m_PropertiesBoolSAtack, m_PlayerAttack.IsAttacking);
       m_Anim.SetBool(m_AnimPropertiesDamages, m_PlayerAttack.Isdamage);
        
        if (GlobalVars.PlayerHP <= 0)
        {
            m_PlayerAttack.IsDiying = true;
             m_Anim.SetBool(m_PropertiesBoolDeath, m_PlayerAttack.IsDiying);
          
        }

    }
}
