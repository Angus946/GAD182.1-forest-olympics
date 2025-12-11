using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValleyGlideScript : MonoBehaviour
{
    [Header("Launch Settings")]
    public float launchForce = 8f;   // Initial upward and forward push when starting

    [Header("Vulture Movement Settings")]
    public float flapForce = 8f; // Force applied when flapping
    public float glideSpeed = 12f; // Horizontal movement speed
    public float gravityScale = 0.5f; //Gravity effect on vulture
    public int maxFlaps = 3; // Maximum number of flaps allowed

    [Header("Soft Landing Settings")]
    public float softLandingHeight = 2f; // Height above ground to begin slowing
    public float softLandingForce = 5f; // Upward force for gentle landing
    public float softLandingDuration = 0.3f; // How long the soft landing lasts

    private Rigidbody2D rb;
    private bool canMove = false;         // Whether vulture can start moving
    private int flapCount = 0;
    private Vector2 startPosition;
    private bool hasLanded = false;

    [Header("UI Elements")]
    public GameObject startPanel; // UI Panel with instructions
    public TextMeshProUGUI startMessageText; // Text showing instructions
    public GameObject endPanel; // UI Panel showing results
    public TextMeshProUGUI endMessageText; // Text showing distance & game over message

    [Header("Environment Setup")]
    public LayerMask groundLayer;         // Ground detection layer

    [Header("Sprites")]
    public Sprite normalSprite;      // Default resting/gliding sprite
    public Sprite flapSprite;        // Wings-out sprite when flapping
    private SpriteRenderer sr;       // Reference to the sprite renderer


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite; // start on the default
        rb.gravityScale = gravityScale;
        rb.simulated = false;            // Disable movement at start
        Time.timeScale = 0f;             // Pause the game
        startPanel.SetActive(true);      // Show start menu
        endPanel.SetActive(false);       // Hide end screen
        // Combine all text info into one TMP text field
        startMessageText.text =
            "Goal: Glide as far down the Valley as you can\n\n" +
            "Flying: Press space to flap your wings & gain altitude, though only 3 times\n\n" +
            "Press 'E' to begin\n\n";
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            if (Input.GetKeyDown(KeyCode.E))
                StartFlight();
            return;
        }

        // Handle flapping
        if (Input.GetKeyDown(KeyCode.Space) && flapCount < maxFlaps)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            sr.sprite = flapSprite; // Change to flapping sprite
            Invoke(nameof(ResetSprite), 0.2f); // revert after 0.2 seconds
            flapCount++;
        }

        // Apply smooth forward gliding force
        rb.AddForce(Vector2.right * glideSpeed * Time.deltaTime, ForceMode2D.Force);

        // Clamp max horizontal speed (optional)
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0, 8f), rb.velocity.y);

        CheckForLanding();
    }
    void ResetSprite()
    {
        sr.sprite = normalSprite;
    }

    void StartFlight()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
        rb.simulated = true;
        sr.sprite = flapSprite;
        Invoke(nameof(ResetSprite), 0.3f);
        rb.AddForce(new Vector2(glideSpeed, launchForce), ForceMode2D.Impulse); // Apply an initial upward and forward launch
        canMove = true;
        flapCount = 0;
        startPosition = transform.position;
    }

    void CheckForLanding()
    {
        // Cast a ray downward to detect ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, softLandingHeight, groundLayer);

        // If ground detected within soft landing height and we haven't landed yet
        if (hit.collider != null && !hasLanded)
        {
            float distanceToGround = hit.distance;

            // If we're close but not yet touching, apply gentle lift to slow descent
            if (distanceToGround > 1f)
            {
                
                sr.sprite = flapSprite;
                Invoke(nameof(ResetSprite), 0.4f);
                rb.AddForce(Vector2.up * softLandingForce * Time.deltaTime, ForceMode2D.Force); // Apply small upward force opposite gravity
            }
            else
            {
                // Actually land when close enough
                hasLanded = true;
                EndFlight();
            }
        }
    }

    void EndFlight()
    {
        canMove = false;
        rb.velocity = Vector2.zero;

        float distanceTravelled = transform.position.x - startPosition.x;

        // Combine all text info into one TMP text field
        endMessageText.text =
            "Game Over!\n\n" +
            "Distance Travelled: " + distanceTravelled.ToString("F1") + " metres\n\n";

        endPanel.SetActive(true);
    }
}
