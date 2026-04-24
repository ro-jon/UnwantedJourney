using JetBrains.Annotations;
using UnityEngine;
 
public class itemPickup : MonoBehaviour
{
    
    public inventory i;
    public void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        



        if (collision.gameObject.CompareTag("PLAYER"))
        {
            i.Additem(gameObject.name);
            
            gameObject.SetActive(false);
        }
    }
}
