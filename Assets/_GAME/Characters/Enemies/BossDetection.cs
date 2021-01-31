﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetection : Detection
{
    [SerializeField]
    private GameObject player;
    
    [SerializeField, Min(.05f)]
    [Tooltip("Defines how far this entity can detect objects")]
    private float m_SightSecondRange = 8f;

    public bool IsInRange = false;


    public void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < m_SightSecondRange)
        {
            Debug.Log("Player in seconde range");
            transform.LookAt(player.transform.position);
            Vector3 vec = -transform.forward  ;
            vec.Normalize();
            //transform.position += vec * Time.deltaTime * 5f;
            IsInRange = true;
        }
        else
        {
            IsInRange = false;
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