using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RabbitMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    Rigidbody2D rb;
    // float multiplier for movespeed
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private Vector2 moveDirection;

    // float multiplier for switching between the three lane
    [SerializeField] private float switchSpeed;

    // int's to represent each lane
    //this is for moving between the lanes
    [SerializeField] private int lane = 1;
    [SerializeField] private int targetLane = 1;
    [SerializeField] private Vector2 targetPositionUp;
    [SerializeField] private Vector2 targetPositionDown;

    // header denoting the input section, and showing the private variables to work in inspector
    [Header("Input")]
    [SerializeField] private InputActionReference switchLaneUp;
    [SerializeField] private InputActionReference switchLaneDown;
    [SerializeField] private InputActionReference moveAction;
    

    [Header("Debug")]
    [SerializeField] private float rayTestLength = 2f;
    [SerializeField] private Vector2 belowLane;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            moveDirection = moveAction.action.ReadValue<Vector2>();
        }

        belowLane = new Vector2(transform.position.x, transform.position.y - 2);

        RaycastHit2D laneUp = Physics2D.Raycast(transform.position, Vector2.up);

        RaycastHit2D laneDown = Physics2D.Raycast(belowLane, -Vector2.up);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (laneUp.collider != null) 
        {
            targetPositionUp = new Vector2(rb.transform.position.x, laneUp.collider.transform.position.y + 1.5f);
        }
        else if (laneUp.collider == null)
        {
            targetPositionUp = new Vector2(rb.transform.position.x, rb.transform.position.y);
        }

        if (laneDown.collider != null)
        {

            targetPositionDown = new Vector2(rb.transform.position.x, laneDown.collider.transform.position.y + 1.5f);
        }
        else if (laneDown.collider == null)
        {
            targetPositionDown = new Vector2(rb.transform.position.x, rb.transform.position.y);
        }


        if (hit)
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "laneOne")
            {
                lane = 1;
                Debug.Log(lane + " is current lane");
            }
            if (hit.collider.tag == "laneTwo")
            {
                lane = 2;
                Debug.Log(lane + " is current lane");
            }
            if (hit.collider.tag == "laneZero")
            {
                lane = 0;
                Debug.Log(lane + " is current lane");
            }
        }
        if (laneDown)
        {
            Debug.Log(laneDown.collider.tag);
        }

        if (laneUp)
        {
            Debug.Log(laneUp.collider.tag);

        }
    }
    private void OnEnable()
    {
        switchLaneUp.action.started += MoveLaneUp;
        switchLaneDown.action.started += MoveLaneDown;
    }
    private void OnDisable()
    {
        switchLaneUp.action.started -= MoveLaneUp;
        switchLaneDown.action.started -= MoveLaneDown;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
      
    }

    private void MoveLaneUp(InputAction.CallbackContext obj)
    {
        RaycastHit2D laneUp = Physics2D.Raycast(transform.position, Vector2.up);
        transform.position = targetPositionUp;
        rb.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y);
        targetPositionUp = new Vector2(rb.transform.position.x, laneUp.collider.transform.position.y + 1.5f);

    }
    private void MoveLaneDown(InputAction.CallbackContext obj)
    {

        RaycastHit2D laneDown = Physics2D.Raycast(belowLane, -Vector2.up);
        transform.position = targetPositionDown;
        rb.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y);
        if (laneDown.collider == null)
        {
            targetPositionDown = new Vector2(rb.transform.position.x, rb.transform.position.y);
        }
    }
}
