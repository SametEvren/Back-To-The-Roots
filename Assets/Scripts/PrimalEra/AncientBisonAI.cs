using UnityEngine;

public class AncientBisonAI : MonoBehaviour
{
    public float detectionRadius = 10f;
    public Transform player;
    public Transform updatedPlayer;

    private Animator animator;
    private float distanceToPlayer;
    [SerializeField] private float speed;
    private enum AIState { Idle, Alert, Attack, Death };
    private AIState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = AIState.Idle;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        updatedPlayer = player;
        updatedPlayer.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(updatedPlayer);
        
        switch (currentState)
        {
            case AIState.Idle:
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isIdling", true);

                if (distanceToPlayer <= detectionRadius)
                {
                    currentState = AIState.Alert;
                }
                break;
            case AIState.Alert:
                animator.SetBool("isIdling", false);
                animator.SetBool("isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed *Time.deltaTime);
                
                if (distanceToPlayer <= 1f)
                {
                    animator.SetBool("isRunning", false);
                    currentState = AIState.Attack;
                }
                else if (distanceToPlayer > detectionRadius)
                {
                    currentState = AIState.Idle;
                }
                else if (Random.value < 0.5f)
                {
                    currentState = AIState.Idle;
                }
                break;
            case AIState.Attack:
                animator.SetBool("isAttacking", true);
                break;
            case AIState.Death:
                animator.SetBool("isDeath", true);
                break;
        }
    }
}