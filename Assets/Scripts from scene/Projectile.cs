

using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    
    Vector2 Eposition;
    public string targettag = "Enemy";
    GameObject target;
    public float damage = 25;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.right * speed;

        




    }

    // Update is called once per frame
    void Update()
    {

        Vector2 Scale = transform.localScale;
        if
            (rb.linearVelocity.x <= 0)
        {
            Scale.x = -Mathf.Abs(Scale.x);

        }
        else if(rb.linearVelocity.x >= 0)
        {
            Scale.x = Mathf.Abs(Scale.x);
        }
        transform.localScale = Scale;
        
    }
    private void FixedUpdate()
    {
        GameObject target = GameObject.FindWithTag(targettag);
        if (target != null)
        {
            Eposition = target.transform.position;
        }
        Destroy(gameObject, 5f);



        Vector2 Gt = Vector2.MoveTowards(rb.position,Eposition , speed * Time.fixedDeltaTime);
        rb.MovePosition(Gt);



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag(targettag))
        {
           collision.GetComponent<IDamageable>().TakeDamage(damage);

            Destroy(gameObject);    
        }
    }
}






