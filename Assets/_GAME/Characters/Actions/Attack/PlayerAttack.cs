using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    
    private bool isShielded = false;
    public bool IsShielded
    {
        get { return isShielded; }
        set { isShielded = value; }
    }

    private bool isDiying = false;
    public bool IsDiying
    {
        get { return isDiying; }
        set { isDiying = value; }
    } 

    private bool IsDamage = false;

    private bool IsAtack = false;
    public bool IsAttacking
    {
        get { return IsAtack; }
        set { IsAtack = value; }
    }
    public bool Isdamage
    {
        get { return IsDamage; }
        set { IsDamage = value; }
    }

    [SerializeField]
    [Tooltip("The shield duration")]
    private float ShieldMaxDuration = 5f;

    [SerializeField]
    [Tooltip("The shield countdown")]
    private float ShieldCd = 3f;

    private float ShieldDuration = 0f;
    private float ShieldActualCd = 0f;

    [SerializeField]
    private GameObject shield;
    
    [SerializeField]
    private GameObject blade;
    [SerializeField]
    private float m_TmeEcranEnd = 6f;

    private EnemyDetection m_detection;

    private float count = 0f;

    private void Awake()
    {
        m_detection = GetComponent<EnemyDetection>();
    }
    private void Update()
    {
        if (isShielded)
        {
            IsDamage = false;
            Debug.Log("Shielded");
            if(ShieldDuration < ShieldMaxDuration)
            {
                ShieldDuration += Time.deltaTime % 60;
            }
            else
            {
                shield.SetActive(false);
                isShielded = false;
                ShieldDuration = 0;
                ShieldActualCd = ShieldCd;
            }
        }
        else
        {
            if (ShieldActualCd > 0)
            {
                Debug.Log("Shield over");
                ShieldActualCd -= Time.deltaTime % 60;
            }
        }


        if (count > 0)
        {
            count -= Time.deltaTime % 60;
        }
        else
        {
            blade.SetActive(false);
        }

        isDiying = true;
        IsDamage = false;
        Debug.Log("cc");
        TimeEnd(Time.deltaTime);
    }

    public void OnAttack()
    {
        if (!isShielded)
        {
            blade.SetActive(true);
            IsAtack = true;
            count = 0.3f;
            if (m_detection.HasActionnableInRange())
            {
                Debug.Log("Attack");                
                GameObject enemy = m_detection.GetActionnableInRange();
                enemy.GetComponent<EnemyController>().Damage(GlobalVars.PlayerDamages);
                enemy.transform.GetComponent<Rigidbody>().AddForce((enemy.transform.position - transform.position) * 3, ForceMode.Impulse);
            }
        }        
    }

    public void OnBlock()
    {        
        if(ShieldActualCd <= 0)
        {
            Debug.Log("block");
            shield.SetActive(true);
            isShielded = true;
            IsAtack = false;
        }
    }

    /**
     * Damages taken
     */
    public void Damage(int amout)
    {
        if (!isShielded)
        {
            GlobalVars.PlayerHP -= amout;
            IsDamage = true;
            if(GlobalVars.PlayerHP <=0)
            {
                GlobalVars.PlayerHP = 0;
                isDiying = true;
                TimeEnd(Time.deltaTime);
            }
            Debug.Log("HP:" + GlobalVars.PlayerHP);
        }
        IsDamage = false;
    }
    public void TimeEnd(float p_DeltaTime)
    {
        if (isDiying == true && GlobalVars.PlayerHP <= 0)
        {
            m_TmeEcranEnd -= p_DeltaTime;

            Debug.Log(m_TmeEcranEnd);
            if (m_TmeEcranEnd <= 0)
            {
                SceneManager.LoadScene("MenuGameO");
            }
        }
       // return TimeEnd(p_DeltaTime);
    }
}
