using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//To script auto moiazei arketa me ekeino tou player opote apla tha tonisw tis diafores opou einai
public class Enemy : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Vector3 moveDirection;//h keteythinsei pros thn opoia tha kinithei o enemy

    public GameObject gameover;
    public Animator transition;

    //public GameObject gameover;
    public Animator animator;
    public Animator playeranimator;//o animator tou paikth
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    //public Animator transition;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //public GameObject enemyprefab;
    public int maxHealth=100;
    public int currentHealth;
    public int EnemyDamage = 10;

    public float lookRadius = 2f;//to pedio mesa sto opoio anagnwrizei ton paikth

    public Transform target;//o paikths
    public NavMeshAgent agent;//to navmesh agent tou enemy gai thn plohghsh tou ston kosmo

    // Start is called before the first frame update
    void Start()
    {

        target = PlayerManager.instance.player.transform;//target tha ginei o paikths
        agent = GetComponent<NavMeshAgent>();//pairnei to navmesh agent
        currentHealth=maxHealth;//arxikopoiei to health


    }
    
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);//h apostash metaksy paikth kai enemy

        if (distance <= lookRadius)//an h apostash einai mesa sto pedia orashs
        {

            agent.SetDestination(target.transform.position);//paei pros ton paikth o enemy
            

            if (distance <= agent.stoppingDistance)//an perasei to stopping distance
            {

                FaceTarget();//kanei rotate na vlepei ton paikth
                if (Time.time >= nextAttackTime)//epitithetai ston paikth
                {
                    animator.SetBool("isWalking", false);
                    AttackPlayer();
                    nextAttackTime = Time.time + 3f / attackRate;

                }
                

            }
            if (distance > agent.stoppingDistance)//an ksepareasei o paikths to stoppingdistance, tote o enemy menei akinhtos
            {
                animator.SetBool("isWalking", true);
            }
        }
        if (distance > lookRadius)// an to distancec einai megalytero tou pediou orashs, tote o enemy menei idle
        {
            
                animator.SetBool("isWalking", false);
            
        }

    }
    void AttackPlayer()//epitithetai ston paikth, afou prwta elegxei an kanei block
    {   
        
        Collider[] hitplayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
        foreach (Collider player in hitplayer)
        {
            animator.SetTrigger("AttackPlayer");
            if (playeranimator.GetBool("isblocking") == true)
            {
                Debug.Log("Player is Blocking");
            }
            if (playeranimator.GetBool("isblocking") == false)
            {
                player.GetComponent<CartoonHeroMovementScript>().TakeDamage(EnemyDamage);
                player.GetComponent<CartoonHeroMovementScript>().KnockBack(gameObject.transform.position);
                Debug.Log("We hit " + player.name);
            }
            
        }
        //Debug.Log("Attacking Player");
        
    }
    void FaceTarget ()//rotate gia na vlepei ton paikth o enemy
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50f);
    
    
    
    
    }

    public void TakeDamage(int damage)
    {
        currentHealth-=damage;

        animator.SetTrigger("Hurt");
        Debug.Log("Enemy Hit");

        if (currentHealth<=0){

            Die();
        }

    }
    void Die()
    {
        Debug.Log("Enemy Died");
        //Die Animation
        animator.SetBool("isDead",true);
        //Disable the enemy

        agent = GetComponent<NavMeshAgent>();
        agent.Stop();
       
        GetComponent<Collider>().enabled= false;
        this.enabled=false;
        if (this.name == "Character_Chief_01_White")
        {
            StartCoroutine(SaySequence());
           

        }

    }

    IEnumerator SaySequence()
    {
        gameover.SetActive(true);
        Time.timeScale = 0.5f;
        yield return StartCoroutine(Wait()); //will block until SaySth completes
        gameover.SetActive(false);

        //SceneManager.LoadScene(3);
    }
    IEnumerator Wait()
    {
        // your process
        yield return new WaitForSeconds(5);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        // continue process
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelIndex);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
