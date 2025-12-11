using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRabbitRun : MonoBehaviour
{
    [Header("variables")]
    private int firstEnemy;
    private int secondEnemy;
    private float enemySpeed = 10;

    [Header("Game Object References")]
    public GameObject Bear;
    public Rigidbody2D bearRB;
    public GameObject Vulture;
    public Rigidbody2D vultureRB;
    public GameObject Bat;
    public Rigidbody2D batRB;

    // Start is called before the first frame update
    void Start()
    {
        firstEnemy = Random.Range(0, 3);
        secondEnemy = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (secondEnemy == firstEnemy)
        {
            secondEnemy = Random.Range(0, 2);
        }
        

        if (firstEnemy == 0)
        {
            bearRB.velocity = Vector2.left * enemySpeed;
            Debug.Log("Bear chosen");
        }
        else if (firstEnemy == 1)
        {
            vultureRB.velocity = Vector2.left * enemySpeed;
            Debug.Log("Vulture Chosen");
        }
        else if (firstEnemy == 2)
        {
            batRB.velocity = Vector2.left * enemySpeed;
            Debug.Log("Bat Chosen");
        }

        if (secondEnemy == 0)
        {
            bearRB.velocity = Vector2.left * enemySpeed;
            Debug.Log("Bear chosen");
        }
        else if (secondEnemy == 1)
        {
            vultureRB.velocity = Vector2.left * enemySpeed;
            Debug.Log("Vulture Chosen");
        }
        else if (secondEnemy == 2)
        {
            batRB.velocity = Vector2.left * enemySpeed;
            Debug.Log("Bat Chosen");
        }
    }
}
