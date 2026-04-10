
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementOnly : MonoBehaviour

{ 
    public GameObject ins;
    Animator animator; 
    public Rigidbody2D rb;
    public  Vector2 movement;
    public float speed;
    public float JumpForce = 5f;
    bool isGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ins.SetActive(true);
        Invoke("Instruction", 3f);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         movement.x = Input.GetAxis("Horizontal");
         animator.SetFloat("change",movement.x);
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {

            Jump();

           
        }





    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocityY);
        Vector3 Scale = transform.localScale;
        if (movement.x > 0)
        {
            Scale.x = Mathf.Abs(Scale.x);

        }
        else if (movement.x < 0)
        {
            Scale.x = -Mathf.Abs(Scale.x);
        }
        transform.localScale = Scale;

    }
    void Jump()

    {
        isGround = false;
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
    void Instruction()
    {
        ins.SetActive(false);
    }
}
