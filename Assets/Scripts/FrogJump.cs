using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float jumpPower = 0;
    public float timeHeld = 0;
    public float jumpSpeed = 0;
    public float score;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DelayJump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }
    void DelayJump()
    {
        timeHeld += Time.deltaTime;
        jumpPower = 1 + 10f + timeHeld;
        Debug.Log(jumpPower + " Yes");
    }
    void Jump()
    { 
        Debug.Log("Space Released at " + timeHeld);
        jumpSpeed = jumpPower;
        rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        rb.AddForce(transform.right * jumpSpeed, ForceMode2D.Impulse);
        jumpSpeed = 0;
        timeHeld = 0;
    }
}
