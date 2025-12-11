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
        int random = Random.Range(1, 7);
        Debug.Log(random + "before Scene");
        SceneManager.LoadScene(random);
        Debug.Log(random + "afterscene");
    }

}
