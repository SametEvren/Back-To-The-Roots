using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Vector3 direction;
    public Animator animator;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                PlayRun();
                speed = 10f;
            }
            else
            {
                PlayWalk();
                speed = 6f;
            }
        }
        else
        {
            PlayIdle();
        }
    }
    
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
}