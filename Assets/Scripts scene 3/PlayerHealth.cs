using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public GameObject gop;  
    public float CurrentHealth = 100;
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
        CurrentHealth -= damage;    
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            gop.SetActive(true );
        }

    }
}

