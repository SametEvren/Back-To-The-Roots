using System.Collections;
using System.Collections.Generic;
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
}
