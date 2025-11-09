using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitRunScore : MonoBehaviour
{
    public Rigidbody rabbitRB;

    static bool rabbitWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            SceneManager.LoadScene("RabbitRunEnd");
        }
        if (collision.collider.tag == "endpoint")
        {
            rabbitWin = true;
            SceneManager.LoadScene("RabbitRunEnd");
        }
    }
}
