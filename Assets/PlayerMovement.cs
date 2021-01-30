using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Inputs")]
    public Vector2 moveInputs = Vector2.zero;

    [SerializeField]
    private float _speed = 10f;

    public void OnMove(InputValue val)
    {
        moveInputs = val.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {

        if (moveInputs != Vector2.zero)
        {
           Vector3 _Direction =  new Vector3(moveInputs.x, 0f, moveInputs.y);

            _Direction.Normalize();

            transform.position += _Direction * Time.deltaTime * _speed ;
        }
        
    }
}
