using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    
    [SerializeField]
    private float moveSpeed = 3.5f;
    [SerializeField]
    private float jumpForce = 8;
    private float xInput;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        var isMoving = rigidBody.linearVelocity.x != 0;

        animator.SetBool("isMoving", isMoving);
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void HandleMovement()
    {
        rigidBody.linearVelocity = new Vector2(xInput * moveSpeed, rigidBody.linearVelocity.y);
    }

    private void Jump()
    {
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
    }
}
