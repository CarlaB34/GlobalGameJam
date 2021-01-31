using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    [SerializeField]
    private float timer = 2f;
    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }

        timer -= Time.deltaTime;
    }
}
