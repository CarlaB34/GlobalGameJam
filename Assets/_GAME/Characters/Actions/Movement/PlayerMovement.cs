using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Inputs")]
    public Vector2 moveInputs = Vector2.zero;

    [SerializeField]
    private float _speed = 10f;

    private float m_CurrenSpeed;

    [SerializeField]
    private UnityEvent m_Animaiton = new UnityEvent();


    public float Speed
    {
        get { return m_CurrenSpeed; }
        set { m_CurrenSpeed = value; }
    }
    public void OnMove(InputValue val)
    {
        moveInputs = val.Get<Vector2>();
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (moveInputs != Vector2.zero)
        {
            
           
           Vector3 _Direction =  new Vector3(moveInputs.x, 0f, moveInputs.y);

            _Direction.Normalize();

            transform.position += _Direction * Time.deltaTime * _speed ;
            transform.LookAt(transform.position - _Direction);
            m_CurrenSpeed = _speed;
            m_Animaiton.Invoke();
        }
        else
        {
            m_CurrenSpeed = 0;
        }
        
    }
}
