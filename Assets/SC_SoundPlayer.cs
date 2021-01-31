using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerAttack m_PlayerAttack = null;

    [SerializeField]
    private PlayerMovement m_PlayerMove = null;

    [SerializeField]
    AudioSource ShieldActivateSound;
    //[SerializeField]
    //AudioSource AttackSound;
    [SerializeField]
     AudioSource StepSound;


    bool alreadyActivateShield = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerAttack.ShieldDuration == 0f & m_PlayerAttack.IsShielded == true)
        {
            ShieldActivateSound.Play();
        }



        else if (m_PlayerMove.Speed > 0)
        {
            Debug.Log("JE MARCHE");
            StepSound.Play();
        }

        else if (m_PlayerMove.Speed == 0)
        {
            StepSound.Stop();
        }

       /* else if (m_PlayerAttack.IsAttacking == true)
        {
            ShieldActivateSound.Play();
        }

        else if (m_PlayerAttack.IsDiying == true)
        {
            ShieldActivateSound.Play();
        }

        else if (m_PlayerAttack.Isdamage == true)
        {
            ShieldActivateSound.Play();
        }*/



    }
}
