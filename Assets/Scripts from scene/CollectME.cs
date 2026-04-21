using UnityEngine;

public class CollectME : MonoBehaviour
{

    
    playerMovement play;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     play = FindAnyObjectByType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
           play.CurrentHealth  += 50;
           Destroy(gameObject);
        }
    }
}
