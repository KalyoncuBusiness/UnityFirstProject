using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterMovementController characterMovement;
    CharacterAnimationController characterAnimation;
    CharacterCombat characterCombat; 
    Health health;

    private Rigidbody2D rigidBody2D;
    


    public void Awake()
    {
        characterMovement = GetComponent<CharacterMovementController>();
        characterAnimation = GetComponent<CharacterAnimationController>();
        characterCombat = GetComponent<CharacterCombat>(); 
        health = GetComponent<Health>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        SetCharacterState();

        if (Input.GetMouseButtonDown(0) && 
        characterMovement.MovementState != CharacterMovementController.MovementStates.Jumping)
        {
            StartCoroutine(LattackOrder()); 
        }

        else if (Input.GetMouseButtonDown(1) &&
        characterMovement.MovementState != CharacterMovementController.MovementStates.Jumping)
        {
            StartCoroutine(SattackOrder());
        }
    }

    private void SetCharacterState()
    {
        if (characterCombat.isLattacking)
        {
            return;
        }
            
        if (characterMovement.IsGrounded())
        {
            if (rigidBody2D.velocity.x == 0)
            {
                characterMovement.MovementState = CharacterMovementController.MovementStates.Idle;
            }
            else if (characterMovement.isRunning)
            {
                if (rigidBody2D.velocity.x > 0)
                {
                    characterMovement.facingDirection = CharacterMovementController.FacingDirection.Right;
                    characterMovement.MovementState = CharacterMovementController.MovementStates.Running;
                }
                else if (rigidBody2D.velocity.x < 0)
                {
                    characterMovement.facingDirection = CharacterMovementController.FacingDirection.Left;
                    characterMovement.MovementState = CharacterMovementController.MovementStates.Running;
                }
            }
            else if (rigidBody2D.velocity.x > 0)
            {
                characterMovement.facingDirection = CharacterMovementController.FacingDirection.Right;
                characterMovement.MovementState = CharacterMovementController.MovementStates.Walking;
            }
            else if (rigidBody2D.velocity.x < 0)
            {
                characterMovement.facingDirection = CharacterMovementController.FacingDirection.Left;
                characterMovement.MovementState = CharacterMovementController.MovementStates.Walking;
            }

        }
        else
        {
            characterMovement.MovementState = CharacterMovementController.MovementStates.Jumping;
        }
    }

  

    

    private IEnumerator LattackOrder()
    {
        if (characterCombat.isLattacking)
        {
            yield break;
        }
        characterCombat.isLattacking = true;

        characterMovement.MovementState = CharacterMovementController.MovementStates.Lattacking;

        characterAnimation.TriggerLattackAnimation();

        yield return new WaitForSeconds(0.35f);

        characterCombat.Lattack();

        characterCombat.isLattacking = false;

        yield break;
    }

    private IEnumerator SattackOrder()
    {
        if (characterCombat.isSattacking)
        {
            yield break;
        }
        characterCombat.isSattacking = true;

        characterMovement.MovementState = CharacterMovementController.MovementStates.Sattacking;

        characterAnimation.TriggerSattackAnimation();

        yield return new WaitForSeconds(2f);

        characterCombat.Sattack();

        characterCombat.isSattacking = false;

        yield break;
    }



}

