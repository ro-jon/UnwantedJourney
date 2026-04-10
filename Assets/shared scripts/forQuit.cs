using UnityEngine;
using UnityEngine.SceneManagement;

public class forQuit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit(); 
    }
}
