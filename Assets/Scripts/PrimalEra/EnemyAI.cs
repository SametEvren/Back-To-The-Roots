using System;
using System.Collections;
using PrimalEra;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float maxHealth;
    public float health;
    public int strength;

    public Animator animator;
    
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    // public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool playerIn;

    public HealthBar healthBar;

    public bool isDead;

    public string name;
    
    private void Update()
    {
        health = Mathf.Clamp(health, 0, 100);
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (isDead)
            return;
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
    
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        Walk();
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Run();
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Attack();
            // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        health -= damage;
        healthBar.UpdateHealthBar(maxHealth,health);

        if (health <= 0)
        {
            isDead = true;
            Dead();
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerIn = false;
    }

    public void Idle()
    {
        animator.SetBool("isIdling",true);
        animator.SetBool("isWalking",false);
        animator.SetBool("isRunning",false);
        animator.SetBool("isAttacking",false);
    }
    public void Walk()
    {
        animator.SetBool("isIdling",false);
        animator.SetBool("isWalking",true);
        animator.SetBool("isRunning",false);
        animator.SetBool("isAttacking",false);
    }
    
    
    public void Run()
    {
        animator.SetBool("isIdling",false);
        animator.SetBool("isWalking",false);
        animator.SetBool("isRunning",true);
        animator.SetBool("isAttacking",false);
    }
    public void Attack()
    {
        animator.SetBool("isIdling",false);
        animator.SetBool("isWalking",false);
        animator.SetBool("isRunning",false);
        animator.SetBool("isAttacking",true);
    }

    public void Dead()
    {
        animator.SetBool("isIdling",false);
        animator.SetBool("isWalking",false);
        animator.SetBool("isRunning",false);
        animator.SetBool("isAttacking",false);
        animator.SetBool("isDead",true);

        StartCoroutine(LoadNewAnimal());
        IEnumerator LoadNewAnimal()
        {
            yield return new WaitForSeconds(5f);
            if(name != "Columbian Mammoth")
                FightManager.Instance.nextButton.SetActive(true);
            else
            {
                StartCoroutine(Tutorial.Instance.IterateSentence());
            }
        }
    }
    
    public void AttackTheCharacter()
    {
        if(playerIn)
            player.GetComponent<CharacterStats>().TakeDamage(strength);
    }
    
    
}
