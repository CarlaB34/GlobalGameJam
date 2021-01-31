using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public void Collect()
    {
        GlobalVars.NbCollectibles--;
        Destroy(gameObject);
    }
}
