using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAnimationController : MonoBehaviour
{
    [SerializeField] private SpaceCharacterMovement characterMovement;
    [SerializeField] private Animator animator;
    private static readonly int Floating = Animator.StringToHash("Floating");
    private static readonly int Flying = Animator.StringToHash("Flying");
    private static readonly int FlyFaster = Animator.StringToHash("FlyFaster");
    public bool flyFaster;

    void Update()
    {
        if (characterMovement.direction.magnitude > 0.1f)
        {
            if (flyFaster)
                PlayFlyFaster();
            else
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
        animator.SetBool(FlyFaster, false);
    }

    void PlayFlying()
    {
        animator.SetBool(Floating, false);
        animator.SetBool(Flying, true);
        animator.SetBool(FlyFaster, false);
    }

    void PlayFlyFaster()
    {
        animator.SetBool(Floating, false);
        animator.SetBool(Flying, false);
        animator.SetBool(FlyFaster, true);
    }
}
