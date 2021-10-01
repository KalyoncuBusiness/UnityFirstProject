using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayJumpingAnim()
    {
        animator.SetBool("isJumping", true);
    }

    public void PlayIdleAnim()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRunning", false);
    }

    public void PlayRunningAnim()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", false);
        animator.SetBool("isWalking", false);
    }

    public void PlayWalkingAnim()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRunning", false);
    }


    public void StopRunningAnim()
    {
        animator.SetBool("isRunning", false);
    }

    public void StopWalkingAnim()
    {
        animator.SetBool("isWalking", false);
        
    }
    
    public void StopJumpingAnim()
    {
        animator.SetBool("isJumping", false);
    }

    public void TriggerLattackAnimation()
    {
        animator.SetTrigger("Lattacking");
    }
    
    public void TriggerSattackAnimation()
    {
        animator.SetTrigger("Sattacking");
    }

}
