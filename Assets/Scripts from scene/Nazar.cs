
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Nazar : MonoBehaviour , IDamageable 
{
    private float distance;
    Vector2 movestep;
    private float patrolRange = 15f;
    private float chaseRange = 7f;
    private float attackRange = 2f;

    enum nazarstate { Patrol, Chase ,Attack};
    nazarstate currentstate = nazarstate.Patrol;
    SpriteRenderer Sr;
    public GameObject Door;
    public Animator animator;
    public GameObject collect;
    public Slider nazarbar;
    public Rigidbody2D rb;
    public float CurrentHealth = 100;
    public GameObject Player;
   
    public GameObject gameoverpanel;
    playerMovement PlayerMovement;
    public float speed = 0.3f;
    public float drophealth = 100;
    bool isDead = false; 
    bool spawned = false;
        
   
    bool canAttack = true;
    public float attackDamage = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerMovement = Player.GetComponent<playerMovement>();
        Debug.Log("PLayer movement found " +  PlayerMovement);
        rb= GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        switch (currentstate)
        {
            case nazarstate.Patrol: Patrol(); break;
            case nazarstate.Chase: Chase(); break;
            case nazarstate.Attack: Attack(); break;
        }
      
        Vector3 scale = transform.localScale;
        {
            if (Player.transform.position.x > transform.position.x)
                scale.x = Mathf.Abs(scale.x); // face right
            else
                scale.x = -Mathf.Abs(scale.x); // face left
            transform.localScale = scale;
        }
    }
    
    private void FixedUpdate()
    {

        
          
        

        distance = Vector2.Distance(rb.position, Player.transform.position); 
      
        if (distance <= attackRange)
        {
            currentstate = nazarstate.Attack;
        }else if(distance <= chaseRange)
        {
            currentstate = nazarstate.Chase;    

        }else
        {
            currentstate=nazarstate.Patrol;
        }
        
       
        
        
      



    }
        void Attack()
        {
        if (canAttack)
        {

            PlayerMovement.TakeDamage(attackDamage);
            StartCoroutine(change());
            Debug.Log("NAzar attack player healtha drop and euals" + PlayerMovement.CurrentHealth);

            animator.SetTrigger("Eattack");
            StartCoroutine(check());
            StartCoroutine(change());

        }

    }
        void Patrol() { }
    void Chase()
    {
        Vector2 movestep = Vector2.MoveTowards(rb.position, Player.transform.position, speed * Time.fixedDeltaTime);

        rb.MovePosition(movestep);

    }
    
    IEnumerator check()
    {
        canAttack = false;
        yield return new WaitForSeconds(2f);
        canAttack = true;   
    }

    public void TakeDamage(float aura)
    {

        CurrentHealth -= aura;
        nazarbar.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            isDead = true;
            if (!spawned && CurrentHealth <= drophealth * 0.5f)
            {
                collect.SetActive(true);
                spawned = true;
             

            }
            
           gameObject.SetActive(false);
           Door.SetActive (true );
             
        }

    }
    IEnumerator change()
    {
        Sr.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        Sr.color = Color.white;
    }
}

