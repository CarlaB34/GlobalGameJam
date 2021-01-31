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

    private static readonly int m_SpeedAnimProperties = Animator.StringToHash("speed");
    private static readonly int m_SpeedAnimPropertiesBool = Animator.StringToHash("collision");
    private static readonly int m_SpeedAnimPropertiesLife = Animator.StringToHash("life");
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
        m_Anim.SetFloat(m_SpeedAnimPropertiesBool, GlobalVars.PlayerHP);
    }
}
