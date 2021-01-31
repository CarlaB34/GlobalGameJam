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
    private static readonly int m_AnimPropertiesBool = Animator.StringToHash("collision");
    private static readonly int m_AnimPropertiesLife = Animator.StringToHash("life");
    // Start is called before the first frame update
    void Start()
    {
        //m_PlayerMove = new PlayerMovement();

        // m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log(m_PlayerMove.Speed);
        Debug.Log(m_Anim);
        m_Anim.SetFloat(m_SpeedAnimProperties,m_PlayerMove.Speed);
       m_Anim.SetFloat(m_AnimPropertiesBool, GlobalVars.PlayerHP);
        m_Anim.SetBool(m_AnimPropertiesBool, m_PlayerAttack.IsShielded);
    }
}
