using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class roboAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject PLayer;
    bool canAttack = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
    public void eAttack()
    {
        if (canAttack)
        {
            Instantiate(projectilePrefab, (Vector2)transform.position + Vector2.right * 2f, Quaternion.identity);
            StartCoroutine(cool());
            Debug.Log("Shoot");
        }
        

    }
    IEnumerator cool()
    {
       
            
            canAttack = false;
            yield return new WaitForSeconds(2f);
            canAttack = true;
        
    }
}
