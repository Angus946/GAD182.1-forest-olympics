using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    // raycast returns whether player is grounded
    private bool grounded;

    // float multiplier for movespeed
    private float moveSpeed;

    // float multiplier for switching between the three lane
    private float switchSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (hit)
        {
            Debug.Log(hit + "raycast hit something");
        }
    }
}
