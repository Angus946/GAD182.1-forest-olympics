using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
        
    }
    public void LoadSceneName(string sceneName)
    {
        int random = Random.Range(1, 8);
        Debug.Log(random + "before Scene");
        SceneManager.LoadScene(random);
        Debug.Log(random + "afterscene");
    }

    public void loadGameSelect(string sceneName)
    {
        
        SceneManager.LoadScene("GameSelect");
        
    }

    public void Pigeon(string sceneName)
    {
        SceneManager.LoadScene(7);
    }

}
