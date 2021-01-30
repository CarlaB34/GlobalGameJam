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
        Debug.Log("collect1");
        if (m_detection.HasActionnableInRange())
        {
            Debug.Log("collect2");
            //m_detection.GetActionnableInRange().GetComponent<Actions>().perform();
        }
    }
}
