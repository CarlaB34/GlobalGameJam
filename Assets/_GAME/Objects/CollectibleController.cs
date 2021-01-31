using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public Transform Player;
    bool HasObject;

    public void Collect()
    {
        if (HasObject == false)
        {
            GlobalVars.NbCollectibles++;
            this.transform.parent = Player;
            HasObject = true;
        }

        else
        {
            GlobalVars.NbCollectibles--;
            this.transform.parent = null;
            HasObject = false;

        }

    }

    private void Update()
    {
        Debug.Log(HasObject);
    }



}
