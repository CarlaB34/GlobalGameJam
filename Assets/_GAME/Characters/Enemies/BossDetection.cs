using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetection : Detection
{
    [SerializeField]
    private GameObject player;
    
    [SerializeField, Min(.05f)]
    [Tooltip("Defines how far this entity can detect objects")]
    private float m_SightSecondRange = 8f;

    public void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < m_SightSecondRange)
        {
            Debug.Log("Player in seconde range");
            transform.LookAt(player.transform.position);
            transform.position += -transform.forward * Time.deltaTime;
        }

        if (HasActionnableInRange())
        {
            Debug.Log("Player in first range");
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        // Draw sight range gizmo
        Gizmos.color = DebugSettings.sightRangeGizmosColor;
        Vector3 start = DetectionOrigin;
        Gizmos.DrawWireSphere(start, m_SightSecondRange);
    }

}
