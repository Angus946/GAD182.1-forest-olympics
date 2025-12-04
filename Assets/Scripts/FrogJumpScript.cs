using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class FrogJumpScript : MonoBehaviour
{
    public float gravity = 1f;
    public float jumpPower = 0;
    public float timeHeld = 0;
    public float jumpSpeed = 0;
    public bool hasJumped = false;
    public float score;
    Rigidbody2D rb;

    public float delay = .5f;
    float timer;

    LayerMask floor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        floor = LayerMask.GetMask("floor");
        RaycastHit2D hit = (Physics2D.Raycast(transform.position, Vector2.right));
        if (hit)
        {
            Debug.Log(hit + "rayhit collider");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1000f);
        }

        if (Input.GetKey(KeyCode.Space) && (hasJumped==false))
        {
            DelayJump();
        }
        if (Input.GetKeyUp(KeyCode.Space) && (hasJumped == false))
        {
            Jump();
        }
        Debug.Log("jumpPower is " + jumpPower);
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
    }
    void DelayJump()
    {
        timeHeld += Time.deltaTime;
        jumpPower = 1f + (5f * timeHeld);
        
    }
    void Jump()
    {
        Debug.Log(jumpPower + " Yes");
        Debug.Log("Space Released at " + timeHeld);
        jumpSpeed = jumpPower;
        rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        rb.AddForce(transform.right * jumpSpeed, ForceMode2D.Impulse);
        jumpSpeed = 0;
        timeHeld = 0;
        hasJumped = true;
    }
   
}
