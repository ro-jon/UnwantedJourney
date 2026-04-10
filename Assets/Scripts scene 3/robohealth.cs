using UnityEngine;

public class robohealth : MonoBehaviour, IDamageable
{
    public GameObject win;
   
    public float currentHealth = 100f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            win.SetActive(true);

        }
    }
}
