using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isShielded = false;

    [SerializeField]
    [Tooltip("The shield duration")]
    private float ShieldMaxDuration = 5f;

    [SerializeField]
    [Tooltip("The shield countdown")]
    private float ShieldCd = 3f;

    private float ShieldDuration = 0f;
    private float ShieldActualCd = 0f;


    private EnemyDetection m_detection;

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

        
    }

    public void OnAttack()
    {
        if (!isShielded)
        {
            if (m_detection.HasActionnableInRange())
            {
                Debug.Log("Attack");
                //m_detection.GetActionnableInRange().GetComponent<Actions>().perform();
            }
        }        
    }

    public void OnBlock()
    {        
        if(ShieldActualCd <= 0)
        {
            Debug.Log("block");
            isShielded = true;
        }
    }
}
