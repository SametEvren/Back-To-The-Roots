using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAnimationController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Animator animator;
    private static readonly int Floating = Animator.StringToHash("Floating");
    private static readonly int Flying = Animator.StringToHash("Flying");

    void Update()
    {
        if (characterMovement.direction.magnitude > 0.1f)
        {
            PlayFlying();
        }
        else
        {
            PlayFloating();
        }
    }

    void PlayFloating()
    {
        animator.SetBool(Floating, true);
        animator.SetBool(Flying, false);
    }

    void PlayFlying()
    {
        animator.SetBool(Floating, false);
        animator.SetBool(Flying, true);
    }
}
