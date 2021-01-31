using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationALter : MonoBehaviour
{
    [SerializeField]
    private Animator m_Anim;

    [SerializeField]
    private BossDetection m_bossDetection;

    private static readonly int m_SpeedAnimPropertiesWalk = Animator.StringToHash("speed");
    private static readonly int m_SpeedAnimProperties = Animator.StringToHash("IsRange");
    private static readonly int m_PropertiesBoolTalk = Animator.StringToHash("isTalk");
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
        //si on entre dans range on passe de idle a walk et on fait mouvoir
        m_Anim.SetBool(m_SpeedAnimProperties, m_bossDetection.IsInRange);
        m_Anim.SetFloat(m_SpeedAnimPropertiesWalk, m_bossDetection.SpeedCurrentBosss);
        //m_Anim.SetFloat(m_AnimPropertiesLife, GlobalVars.PlayerHP);
      
        //m_Anim.SetBool(m_PropertiesBoolShield, m_PlayerAttack.IsShielded);
        //m_Anim.SetBool(m_AnimPropertiesDamages, m_PlayerAttack.Isdamage);

        //if (GlobalVars.PlayerHP <= 0)
        //{
        //    m_PlayerAttack.IsDiying = true;
        //    m_Anim.SetBool(m_PropertiesBoolDeath, m_PlayerAttack.IsDiying);
        //    Debug.Log("mort");
        //}
    }
}
