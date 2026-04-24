
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
    //using state machine to declare the state of the enemy
    //depending on the state opening dialogue or attack

    enum snakestate
    {
        Patrol, Chase, Dialogue
    }
    snakestate currentstate = snakestate.Patrol;
    // declare the current state and start checking distance to see any changes that matches the if conditions to switch state.
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        script = script.GetComponent<playerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        //just flip the enemy position based on current position to match the direction of where the player is
        
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
        //getting the distance and then checking the distance;
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
        // chase the player  but only when the distance is close enough to switch the current state to chase state and run this code
        Vector2 follow = Vector2.MoveTowards(rb.position, Players.transform.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(follow);
    }
    void dialogue()
    {
        //dialogie system checking if the dialogue system is called or not then running it
        if (!isdialoguestarted)
        {
            isdialoguestarted = true;
            DialoguePanel.SetActive(true);
            NameText.text = "Snake ";
            Dialoguetext.text = "Hello King ....you have died . Nazar is waiting for you in the next room";
            StartCoroutine(NextLine());
        }
    

    }
    // 
    
        IEnumerator Helper()
        {
            while (!Input.GetKeyDown(KeyCode.Return))
            //check whether the Enter button has been pressed or not

            {
                yield return null;
            // if not pause and check next frame

            }
            yield return null;
        //once confirm the Enter button then next code

        }
    // to check where the user has pressed Enter or not if yes then change dialogue
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
            //game object that has function run on click 
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

