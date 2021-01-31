using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Movement : MonoBehaviour
{
    public Vector3 controller;
    public CharacterController controllerCharacter;
    public float speed = 6f;

    public float turnsmoothtime = 0.1f;
    float turnsmoothvelocity;

    // Start is called before the first frame update
    void Start()
    {
        




    }

    // Update is called once per frame
    void Update()
    {


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

           float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 0, ref turnsmoothvelocity, turnsmoothtime);

            controllerCharacter.Move(direction * speed * Time.deltaTime);
          //  transform.position += controller * speed * Time.deltaTime;
        }


    }
}
