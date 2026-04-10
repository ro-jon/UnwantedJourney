using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(time());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
