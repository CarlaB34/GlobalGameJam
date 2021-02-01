using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectEgo : MonoBehaviour
{
    [SerializeField]
    private int m_DistanceSecur;
    [SerializeField]
    private int m_DistanceOneRange;
    [SerializeField]
    private int m_DistanceTwoRange;

    [SerializeField]
    private Transform m_Player;
    [SerializeField]
    private Transform m_PointerPlayer;

    [SerializeField]
    private string m_Narration;
    [SerializeField]
    private Vector3 m_DirCompass;
    [SerializeField]
    private Vector3 m_Direction;

    [SerializeField]
    private bool m_ActivateNarration = false;
    [SerializeField]
    private bool m_ActivateWait = false;

    [SerializeField]
    private float m_WaitFlee = 2f;

    // Start is called before the first frame update
    void Start()
    {
        m_PointerPlayer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //si j'entre da ma premier range
        if (Vector3.Distance(transform.position, m_Player.position) < m_DistanceOneRange)
        {
            Debug.Log("enter 1 range: " + m_DistanceOneRange);
            m_PointerPlayer.gameObject.SetActive(true);
            m_ActivateNarration = true;
            if (m_ActivateNarration == true)
            {
                Debug.Log(m_Narration);
            }

            //flee player
            if(m_ActivateWait == true)
            {
                m_ActivateWait = true;
                m_WaitFlee -= Time.deltaTime;
                
            }
           
            if(m_WaitFlee <=0)
            {
                m_WaitFlee = 0;
                Flee();
                m_ActivateWait = false;
            }

            //PointerToPlayer();
            if (m_ActivateWait == false)
            {
                m_WaitFlee -= Time.deltaTime;
                m_WaitFlee = 3f;
            }
        }


        //si j'entre dans ma deuxieme range
        if (Vector3.Distance(transform.position, m_Player.position) < m_DistanceTwoRange)
        {

            Debug.Log("enter 2 range");
            Debug.Log(m_DistanceSecur);
        }
    }

    private void Flee()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 5, Color.red);

       

        RaycastHit l_Hit;
        Ray l_Ray = new Ray(transform.position, Vector3.forward);
        int l_LayerMask = LayerMask.GetMask("default");

        if (Physics.Raycast(l_Ray, out l_Hit ))
        {
            m_Direction = transform.position + l_Hit.point;

            //transform.Translate(m_Direction * l_PatrolAltere.Speed * Time.deltaTime);
            //// l_Hit.point = ;
            //  transform.position = Vector3.Slerp(m_Direction, l_Hit.point, 10);

        }



    }
    private void PointerToPlayer()
    {
        //m_DirCompass = m_Player.position - transform.position;
        //float l_Angle = Mathf.Atan2(m_DirCompass.x, m_DirCompass.z);
        //Quaternion l_AngleRotation = Quaternion.AngleAxis(l_Angle, Vector3.forward);
        //m_PointerPlayer.transform.rotation = Quaternion.Slerp(m_PointerPlayer.transform.rotation, l_AngleRotation, 1 * Time.deltaTime);
        //Debug.Log("je vise le joueur");
    }

    private void OnDrawGizmos()
    {
        if (m_DistanceOneRange < m_DistanceSecur)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, m_DistanceOneRange);
        }
        if (m_DistanceTwoRange < m_DistanceOneRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_DistanceTwoRange);
        }

        if (m_DistanceOneRange < m_DistanceSecur)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, m_DistanceSecur);
        }

    }

}
