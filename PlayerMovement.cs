using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D RB;
    public Animator Anim;

    private Vector2 MoveDirection;
    private Vector2 LastMoveDirection;

    // Update is called once per frame
    void Update()
    {
        //Processing inputs
        ProcessInputs();
        Animate();
    }

    void FixedUpdate()
    {
        //Physics calculations
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && MoveDirection.x != 0 || MoveDirection.y != 0)
        {
            LastMoveDirection = MoveDirection;
        }

        MoveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        RB.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    void Animate()
    {
        Anim.SetFloat("AnimMoveX", MoveDirection.x);
        Anim.SetFloat("AnimMoveY", MoveDirection.y);
        Anim.SetFloat("AnimMoveMagnitude", MoveDirection.magnitude);
        Anim.SetFloat("AnimLastMoveX", LastMoveDirection.x);
        Anim.SetFloat("AnimLastMoveY", LastMoveDirection.y);
    }
}
