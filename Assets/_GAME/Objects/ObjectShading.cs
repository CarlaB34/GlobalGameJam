using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShading : MonoBehaviour
{
    [SerializeField]
    private float fadeMin = 0.2f;
    private Material material;
    [SerializeField]
    private float fadeTime = 0.2f;
    private bool onSight { get; set; }

    private void Awake()
    {
        this.material = gameObject.GetComponent<Renderer>().material;
        onSight = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (onSight && material.color.a >= fadeMin)
        {
            Color newCol = material.color;
            newCol.a -= Time.deltaTime * fadeTime;
            material.SetColor("_Color", newCol);
        }
        else if(!onSight)
        {
            Color newCol = material.color;
            newCol.a = 1; ;
            material.SetColor("_Color", newCol);
        }

        onSight = false;
    }

    public void fade()
    {
        onSight = true;        
    }

}
