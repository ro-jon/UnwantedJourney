using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject projectileprefab;
    PlayerMovementOnly playerMovementOnly;
    public Projectile projectiles;
    bool isSpawned = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectiles = FindAnyObjectByType<Projectile>();
        playerMovementOnly = GetComponent<PlayerMovementOnly>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawned && Input.GetKeyDown(KeyCode.X))
        {
           
            Attack();
            

        }

        
    }
    void Attack()
    {
        Instantiate(projectileprefab,(Vector2) transform.position + new Vector2(playerMovementOnly.movement.x,0) * 0.5f,Quaternion.identity);
      //  projectileprefab.SetActive(true);
    }
}
