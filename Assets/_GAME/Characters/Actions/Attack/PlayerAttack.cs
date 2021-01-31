using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isShielded = false;
    public bool IsShielded
    {
        get { return isShielded; }
        set { isShielded = value; }
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
        
    }

    public void OnAttack()
    {
        if (!isShielded)
        {
            blade.SetActive(true);
            count = 0.3f;
            if (m_detection.HasActionnableInRange())
            {
                Debug.Log("Attack");                
                GameObject enemy = m_detection.GetActionnableInRange();
                enemy.GetComponent<EnemyController>().Damage(GlobalVars.PlayerDamages);
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
            Debug.Log("HP:" + GlobalVars.PlayerHP);
        }
    }
}
