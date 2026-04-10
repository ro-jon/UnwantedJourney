using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int sceneToToad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
  private void OnTriggerEnter2D(Collider2D other)
    {
        
       if(other.gameObject.CompareTag("PLAYER")){
            Debug.Log("check");
            SceneManager.LoadScene(sceneToToad);

        }
    }
}

