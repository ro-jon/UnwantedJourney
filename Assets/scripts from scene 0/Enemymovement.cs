
using System.Collections;


using UnityEngine;
using UnityEngine.Assemblies;




public class Enemymovement : MonoBehaviour,IDamageable
{
    private float distance;
    private float patrolRange = 15f;
    private float chaseRange = 10f;
    private float dialogueRange = 1f;
    public GameOverPanel Gop;
    public playerMovement script;
    public GameObject Players;
    public Rigidbody2D rb;
    public float speed;
    public GameObject DialoguePanel;
    public GameObject yesbutton;
    public GameObject Door;
    public GameObject nobutton;
    public TMPro.TextMeshProUGUI Dialoguetext;
    public TMPro.TextMeshProUGUI NameText;
    public float talkingrange = 1.15f;
    public float AttackDamage = 25;
    public float StopRange = 2f;
    public float maxDistance = 9f;
    bool isStopped = false;
    bool isdialoguestarted = false;

    enum snakestate
    {
        Patrol, Chase, Dialogue
    }
    snakestate currentstate = snakestate.Patrol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        script = script.GetComponent<playerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 scale = transform.localScale;
        if (Players.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);


        }
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
      
        switch (currentstate)
        {
             case snakestate.Patrol:patrol();break;
             case snakestate.Chase:chase();break;
             case snakestate.Dialogue:dialogue();break;  
        }

    }
    private void FixedUpdate()
    {
        distance = Vector2.Distance(rb.position, Players.transform.position);
        if (distance <= dialogueRange) { currentstate = snakestate.Dialogue; }
        else if (distance <= chaseRange)
        {
            currentstate = snakestate.Chase;
        }
        else
        {
            currentstate = snakestate.Patrol;
        }


    }


        
       
    void patrol()
    {

    }
    void chase()
    {

        Vector2 follow = Vector2.MoveTowards(rb.position, Players.transform.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(follow);
    }
    void dialogue()
    {
        if (!isdialoguestarted)
        {
            isdialoguestarted = true;
            DialoguePanel.SetActive(true);
            NameText.text = "Snake ";
            Dialoguetext.text = "Hello King ....you have died . Nazar is waiting for you in the next room";
            StartCoroutine(NextLine());
        }
    

    }
        IEnumerator Helper()
        {
            while (!Input.GetKeyDown(KeyCode.Return))
            {
                yield return null;
            }
            yield return null;
        }
        IEnumerator NextLine()
        {
            yield return StartCoroutine(Helper());
            //King Line
            NameText.text = "King ";
            Dialoguetext.text = "What ? who are you? I am the King! I am not dead!";
            yield return StartCoroutine(Helper());
            //King LIne2
            Dialoguetext.text = " I can still feel my hands! I am Alive!";
            yield return StartCoroutine(Helper());
            //snakeLIne
            NameText.text = "Snake";
            Dialoguetext.text = "Prepare yourself .... Will you accept your Fate";
            yield return StartCoroutine(Helper());
            // Button show
            yesbutton.SetActive(true);
            nobutton.SetActive(true);

        }





    
    public void OnyesClicked()
    {
        DialoguePanel.SetActive(false);
        Door.SetActive(true);
        gameObject.SetActive(false);

        // kill the snake
    }

    public void OnnoClicked()

    {
        DialoguePanel.SetActive(false);
        Players.SetActive(false);
        Gop.showGameOver();
    }
     public void TakeDamage(float damage) { }
} 

