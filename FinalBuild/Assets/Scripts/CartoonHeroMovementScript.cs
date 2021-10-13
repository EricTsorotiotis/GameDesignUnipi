using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script xeirismou tou paikth
//se oles tis kinhseis tou paikth kalw ta katallhla animations apo ton animator "anim"

public class CartoonHeroMovementScript : MonoBehaviour
{
    
    public CharacterController controller;//character contrroller tou paikth
    
    public Rigidbody playerRigidbody;//rigidbody tou paikth

    public float knocktime;//o xronos pou o paikths tha exei knockback apo hit tou antipalou

    public WeaponSwitching weapon;//refernce sthn class weaponswitching,wste na dw poio oplo exw kai na rythmisw to damage tou paikth
    private bool toucheswater = false;//elegxw an einai sto nero kai prepei na xasei o paikths
    
    public HealthSystem healthSystem;//to health tou paikth opws fainetai panw aristera sto hud
    public float speed = 2f;//h taxythta kinhshs tou paikth
    public float turnsmoothTime= 0.1f;//poso xrono thelei gia na strivei o paikths
    public float gravity = 100.0F;//varythta paikth

    public int maxHealth;//max zwh arxikh
    public int currentHealth;//zwh pou menei ston paikth
    //public int level = 1;

    public string difficulty;//h dyskolia pou epilexthike

    float trurnsmoothVelocity;//taxyhtha otan strivei o paikths
    //private bool freeze;
    public Animator anim;// o animator tou paikth

    public Transform AttackPoint;// to shmeio pou otan erthei se epafh me enemy, kanei damage
    public float attackrange = 0.5f;//to euros ths epithesis tou paikth
    public LayerMask enemyLayers;// to layer tou antipalou
    public int attackDamage=20;//poso damage kanei o paikths
    public float attackRate=2f;//poso grhgora xtypa o paikths
    float nextAttackTime=0f;//pote mporei na ksanaepitethei

    SavePlayerPos playerPosData;//class Saveplayerpos gia na apothikeuei thn thesi tou paikth
    public GameObject deathui;//to screen pou tha fanei otan pethanei o paikths

    private void Awake()
    {
        //elegxw to difficulty gia na kanw allages sto paixnidi
        if (difficulty == "easy")
        {
            attackDamage = attackDamage + 10;
        }
        if (difficulty == "hard")
        {
            attackDamage = attackDamage - 5;
        }
        //fortwne thn thesi tou paikth
        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        //edw fortwnw to difficulty kai thn ypoloiph zwh tou paikth
        difficulty = PlayerPrefs.GetString("difficulty");
        Debug.Log("Difficulty Selected is: " + difficulty);
        currentHealth = PlayerPrefs.GetInt("remainingHealth");
        maxHealth = PlayerPrefs.GetInt("maxHealth");
        controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for Water
        if (controller.transform.position.y <= 18.4)
        {
            toucheswater = true;
            Die();
        }
        //End check for water

        //MOVEMENT BUTTONS
        if (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)  )
		{
            anim.SetBool("iswalking",true);           
           
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) )
		{
            if(Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)){}
            else{
                anim.SetBool("iswalking", false);
            }
	
		}
        //MOVEMENT BUTTONS END



        //ATTACK
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                Attack();
                nextAttackTime= Time.time + 1f/attackRate;
            }
        }
       
        
        //ATTACK END

        /////Block
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            anim.SetBool("isblocking", true);
        }
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            anim.SetBool("isblocking", false);
        }



        /////BlockEnd

        //MOVEMENT
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude>=0.1f)
        {
            float targetAngle= Mathf.Atan2(direction.x,direction.z)* Mathf.Rad2Deg;
            float angle=Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref trurnsmoothVelocity,turnsmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            direction.y -= gravity * Time.deltaTime;

            controller.Move(direction*speed*Time.deltaTime);
        }
        //MOVEMENT END
    }

    void Attack()
    {
        if (weapon.selectedWeapon == 2)
        {
            attackDamage = 50;
        }

        anim.SetTrigger("attack");
        //elegxw an akoumpw me to attack kapoion enemy
        Collider [] hitenemies= Physics.OverlapSphere(AttackPoint.position,attackrange,enemyLayers);
        
        foreach(Collider enemy in hitenemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("We hit" + enemy.name+ "with " + attackDamage + " attack damage ");
        }

        
        
    }

    public void KnockBack(Vector3 enemy)
    {
        //gia to knockback kanw to rigidbody non-kinematic
        //kai tou vazw kapoio force gia na to metakinisw sxetika me ton enemy
        playerRigidbody.isKinematic = false;
        Debug.Log("Moving Back!");
        Vector3 moveDirection = playerRigidbody.transform.position - enemy ;
        playerRigidbody.AddForce(moveDirection.normalized * 100f);
        StartCoroutine(KnockCo(playerRigidbody));

    }
    private IEnumerator KnockCo(Rigidbody player)
    {
        //edw perimenw ton xrono tou knocktime kai ksanaenergopoiw to kinematic tou paikth
        yield return new WaitForSeconds(knocktime);
        player.velocity = Vector3.zero;
        player.isKinematic = true;
    }
    public void TakeDamage(int damage)//o paikths xanei pontous zwhs kai an exei <=0 ,tote kalw thn die
    {
        currentHealth -= damage;
        HealthSystem.Instance.TakeDamage(damage);
        anim.SetTrigger("Hurt");        
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()//apenergopoiei ton paikth kai anoigei to screen tou death
    {
        if (toucheswater == true)
        {
            Debug.Log("Player Died in the water");
            anim.SetTrigger("waterdeath");
            GetComponent<Collider>().enabled = false;
            this.enabled = false;
            return;
        }
        Debug.Log("Player Died");
        //Die Animation
        anim.SetBool("isDead", true);
        //Disable the player

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        deathui.SetActive(true);

    }
    private void OnDrawGizmosSelected()//xrhsimo tool gia ton editor,etsi wste na vlepw to attackpoint tou paikth
        {
            if(AttackPoint==null){
                return;
            }
            Gizmos.DrawWireSphere(AttackPoint.position,attackrange);
        }
}
