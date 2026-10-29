using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;

    [Header("Attack details")]
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;


    [Header("Movement details")]
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8;
    private float xInput;
    private bool isFacingRight = true;


    [Header("Collision details")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private bool canMove = true;
    private bool canJump = true;

    public void EnableMovementAndJump(bool enable)
    {
        canMove = enable;
        canJump = enable;
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleColission();
        HandleInput();
        HandleMovement();
        HandleAnimations();
        HandleFlip();
    }

    public void DamageEnemies()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        foreach (var enemy in enemyColliders)
        {
            enemy.GetComponent<Enemy>().TakeDamage();
        }

    }

    private void HandleAnimations()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("xVelocity", rigidBody.linearVelocity.x);
        animator.SetFloat("yVelocity", rigidBody.linearVelocity.y);
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            TryToJump();

        if (Input.GetMouseButtonDown(0))
            TryToAttack();
    }

    private void TryToAttack()
    {
        if (isGrounded)
        {
            animator.SetTrigger("attack");
        }
    }

    private void TryToJump()
    {
        if (isGrounded && canJump)
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
    }

    private void HandleMovement()
    {
        if (canMove)
            rigidBody.linearVelocity = new Vector2(xInput * moveSpeed, rigidBody.linearVelocity.y);
        else
            rigidBody.linearVelocity = new Vector2(0, rigidBody.linearVelocity.y);
    }

    private void HandleColission()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void HandleFlip()
    {
        if (rigidBody.linearVelocity.x > 0 && !isFacingRight)
            Flip();
        else if (rigidBody.linearVelocity.x < 0 && isFacingRight)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
