using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float jumpPower = 0;
    public float timeHeld = 0;
    public float jumpSpeed = 0;
    public bool hasJumped = false;
    public float score;
    Rigidbody2D rb;

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
        if (Input.GetKey(KeyCode.Space))
        {
            DelayJump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
        floor = LayerMask.GetMask("floor");
        RaycastHit2D hit = (Physics2D.Raycast(transform.position, Vector2.right, 2, floor));
        if (Physics2D.Raycast(transform.position, Vector2.right, floor))
        {
            Debug.Log(hit + "rayhit collider");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*1000f);
        }
    }
    void DelayJump()
    {
        timeHeld += Time.deltaTime;
        jumpPower = 1f + 5f + timeHeld;
        
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
