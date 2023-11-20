using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    public bool isTurnRight = true;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Flip()
    {
        isTurnRight = !isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }

    private void Update()
    {
        Vector3 nextVector3 = Vector3.zero;
        if (Input.GetKey("w"))
        {
            nextVector3 += Vector3.up * speed * Time.deltaTime;
        } 
        else if (Input.GetKey("s"))
        {
            nextVector3 += Vector3.down * speed * Time.deltaTime;
        }
        
        if (Input.GetKey("a"))
        {
            if(isTurnRight) Flip();
            nextVector3 += -Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            if(!isTurnRight) Flip();
            nextVector3 += Vector3.right * speed * Time.deltaTime;
        }

        _animator.SetBool("isIdle", nextVector3 == Vector3.zero);

        _rigidbody2D.MovePosition(transform.position + nextVector3);
    }
}
