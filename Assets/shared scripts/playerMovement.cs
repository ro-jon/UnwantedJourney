using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.UI;



public class playerMovement : MonoBehaviour
{
    public Animator animator;
    
    public AudioSource audio;
    public Slider HealthBar;
    public GameObject projectileprefab;
    public InputAction moveAction;
    public GameObject gameoverpanel;

    public float CurrentHealth = 100;
    public Rigidbody2D rb;
    Vector2 moveInput;
    public float Speed;
    public float JumpForce;
    bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveAction.Enable();



    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();


        Vector3 scale = transform.localScale;
        if (moveInput.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (moveInput.x < 0)
        { scale.x = -Mathf.Abs(scale.x); }
        transform.localScale = scale;


        Counter();
    }
    private void FixedUpdate()
    {
        rb.position = rb.position + moveInput * Speed * Time.deltaTime;
        animator.SetFloat("Blend",moveInput.magnitude);

    }

    public void TakeDamage(float damage)
    {

        CurrentHealth = CurrentHealth - damage;
        HealthBar.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            isDead = true;
            Debug.Log("Player dies for real ");
            gameoverpanel.SetActive(true);
            gameObject.SetActive(false);
           
            audio.Stop();



        }

    }
    void Counter()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileprefab.SetActive(true );
            Instantiate(projectileprefab, (Vector2)transform.position + Vector2.right * 0.5f, Quaternion.identity);
            animator.SetTrigger("attack");
        }

    }
}

        
           


        
      




        

    
 



