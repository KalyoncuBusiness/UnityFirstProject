using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public enum MovementStates
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Lattacking,
        Sattacking
    }
    public enum FacingDirection
    {
        Right,
        Left
    }

    [Header("Movement Values")]
    public float walkingspeed;
    public float jumpforce;
    public float runningspeed;
    public  bool isRunning;

    [Header("Raycast length and layerMask")]
    public LayerMask plaformLayerMask;
    public float isGroundedRayLength;

    [Header("Movement States")]
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private CharacterAnimationController animController;

    public MovementStates MovementState;
    public FacingDirection facingDirection;


    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animController = GetComponent<CharacterAnimationController>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rigidBody2D.velocity = Vector2.up * jumpforce;
        }
    }

    private void FixedUpdate()
    {
        SetCharacterDirection();
        PlayAnimationsBasedOnState();
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else isRunning = false;

        if (Input.GetKey(KeyCode.A))
        {
            if (isRunning == true)
            {
                rigidBody2D.velocity = new Vector2(-runningspeed, rigidBody2D.velocity.y);
            }
            else
            rigidBody2D.velocity = new Vector2(-walkingspeed, rigidBody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (isRunning == true)
                {
                    rigidBody2D.velocity = new Vector2(+runningspeed, rigidBody2D.velocity.y);
                }
                else
                rigidBody2D.velocity = new Vector2(+walkingspeed, rigidBody2D.velocity.y);
            }
            else
            {
                rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                IsGrounded();
            }
        }


    }
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(spriteRenderer.bounds.center,
         spriteRenderer.bounds.size, 0f, Vector2.down,
          isGroundedRayLength, plaformLayerMask);
        return raycastHit2D.collider != null;
    }



    private void PlayAnimationsBasedOnState()
    {
        switch (MovementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Walking:
                animController.PlayWalkingAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;
            case MovementStates.Lattacking:
                break;
            case MovementStates.Sattacking:
            default:
                break;
        }
    }

    private void SetCharacterDirection()
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                spriteRenderer.flipX = false;
                break;
            case FacingDirection.Left:
                spriteRenderer.flipX = true;
                break;
        }
    }


}
