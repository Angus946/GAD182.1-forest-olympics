using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vulture : MonoBehaviour
{
    [Header("Flight Settings")]
    public float glideSpeed = 5f;
    public float gravityScale = 0.5f;
    public float flapForce = 5f;
    public int maxFlaps = 3;

    [Header("Score")]
    private float startX;
    private float distanceTravelled;

    private Rigidbody2D rb;
    private int flapCount;
    private bool isGrounded = false;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;

        // Launch off cliff
        rb.velocity = new Vector2(glideSpeed, 0f);
        startX = transform.position.x;

        // Allow flapping up to 3 times midair
        if (Input.GetKeyDown(KeyCode.Space) && flapCount < maxFlaps && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, flapForce);
            flapCount++;
            Debug.Log("Vulture is gaining altitutde!");
        }

        // Check for ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // Stop horizontal movement when grounded
        if (isGrounded)
        {
            rb.velocity = Vector2.zero;
            CalculateDistance();
        }
    }



    void CalculateDistance()
    {
        distanceTravelled = transform.position.x - startX;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Vulture has landed!");
            float distanceTravelled = transform.position.x - startX;
            Debug.Log("Distance travelled: " + distanceTravelled + " metres.");
        }
    }

    public void BeginFlight()
    {
        // Give the vulture a small nudge off the cliff
        rb.velocity = new Vector2(glideSpeed, 0f);
    }
}
