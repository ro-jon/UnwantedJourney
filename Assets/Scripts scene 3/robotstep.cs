using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class robotstep : MonoBehaviour
{
    roboAttack ra;
    public GameObject playerit;
    public float speed;
    private float PatrolRange = 50f;
    private float distance;
    private float ChaseRange = 30f;
    private float AttackRange = 5f;
    public Rigidbody2D rb;
    enum robotstate
    {
        Patrol, Chase, Attack

    }
    robotstate currentState = robotstate.Patrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        ra = GetComponent<roboAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(rb.position, playerit.transform.position);
        switch (currentState)
        {
            case robotstate.Patrol: Patrol(); break;
            case robotstate.Chase: chase(); break;
            case robotstate.Attack: Attack(); break;
        }
        Debug.Log("current state" + currentState);
        Debug.Log(distance);
        

    }
    private void FixedUpdate()
    {


        if (distance <= AttackRange) currentState = robotstate.Attack;
        else if (distance <= ChaseRange) currentState = robotstate.Chase;
        else currentState = robotstate.Patrol;


    }
    void chase()
    {   
      Vector2 mv = Vector2.MoveTowards(rb.position, playerit.transform.position, speed * Time.fixedDeltaTime)
            ;
        rb.MovePosition(mv);
        Debug.Log("chasing");
        ra.eAttack();

    }
    void Patrol()
        {
            Debug.Log(distance);
        }
   void Attack()
        {
        ra.eAttack();

        Debug.Log("hi");
        Debug.Log("eAttacl reached" ) ;

    }
    }

