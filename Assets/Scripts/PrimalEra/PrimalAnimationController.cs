using System.Collections;
using System.Collections.Generic;
using PrimalEra;
using UnityEngine;

public class PrimalAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void PlayIdle()
    {
        animator.SetBool("Idle",true);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }

    public void PlayWalk()
    {
        animator.SetBool("Idle",false);
        animator.SetBool("Walk", true);
        animator.SetBool("Run", false);
    }

    public void PlayRun()
    {
        animator.SetBool("Idle",false);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);
    }

    public void PlayJump()
    {
        animator.SetTrigger("Jump");
    }

    public void PlayBackflip()
    {
        animator.SetTrigger("Backflip");
    }

    public void PlayStabbingOne()
    {
        animator.SetTrigger("Stabbing");
    }
    
    public void PlayStabbingTwo()
    {
        animator.SetTrigger("StabbingTwo");
    }
    
    public void PlayStabbingThree()
    {
        animator.SetTrigger("StabbingThree");
    }

    public void Dead()
    {
        animator.SetBool("Idle",false);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("Death", true);
        GetComponent<PrimalCharacterMovement>().isDead = true;
        FightManager.Instance.retryButton.SetActive(true);
    }
    
    
}
