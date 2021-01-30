using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{

    private CollectibleDetection m_detection;

    private void Awake()
    {
        m_detection = GetComponent<CollectibleDetection>();
    }

    public void OnInteract()
    {
        if (m_detection.HasActionnableInRange())
        {
            m_detection.GetActionnableInRange().GetComponent<CollectibleController>().Collect(); ;
        }
    }
}
