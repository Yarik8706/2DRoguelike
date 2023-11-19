using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    public bool isTurnRight = true;

    private Animator _animator;
    public Transform cameraPos;

    private void Start()
    {
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

        transform.position += nextVector3;
    }
}
