using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEgo : MonoBehaviour
{
    [SerializeField]
    private int m_DistanceSecur; 
    [SerializeField]
    private int m_DistanceOneRange;  
    [SerializeField]
    private int m_DistanceTwoRange;

    [SerializeField]
    private Transform Player;

    [SerializeField]
    private string m_Narration;

    [SerializeField]
    private bool m_ActivateNarration = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si j'entre da ma premier range
        if (Vector3.Distance(transform.position, Player.position) < m_DistanceOneRange)
        {
            Debug.Log("enter 1 range: " + m_DistanceOneRange);
            
        }
        
        //si j'entre dans ma deuxieme range
        if (Vector3.Distance(transform.position, Player.position) < m_DistanceTwoRange)
        {
            Debug.Log("enter 2 range");
            Debug.Log(m_DistanceSecur);
        }
    }

    private void OnDrawGizmos()
    {
        if(m_DistanceOneRange < m_DistanceSecur)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, m_DistanceOneRange);
        }
       if(m_DistanceTwoRange < m_DistanceOneRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_DistanceTwoRange);
        }
       
    }

}
