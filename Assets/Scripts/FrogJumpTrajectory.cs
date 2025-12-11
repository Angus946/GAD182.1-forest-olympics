using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJumpTrajectory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FrogJumpScript _frogJump;
    [SerializeField] private Transform _startPoint;

    [Header("trajectory line length")]
    [SerializeField] private int _numberOfSegments = 150;
    [SerializeField] private float _curveLength = 3.5f;
    
    private Vector2[] _segments;
    private LineRenderer _lineRenderer;

    private float _jumpSpeed;
    private float _frogGravity;

    private void Start()
    {
        // create the the segements that make the line
        _segments = new Vector2[_numberOfSegments];

        // getting the line renderer and setting how many segments it has
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _numberOfSegments;

        // grabbing the frog jump script for refence
        _frogJump = GetComponent<FrogJumpScript>();
        _frogGravity = _frogJump.gravity;
        
    }

    private void Update()
    {
        // setting the start position of the line renderer
        Vector2 startPosition = _startPoint.position;
        _segments[0] = startPosition;
        _lineRenderer.SetPosition(0, startPosition);

        // setting the start velocity based on the characters physics
        _jumpSpeed = _frogJump.jumpPower;
        Vector2 startvelocity = (transform.right * (_jumpSpeed)) + (transform.up * (_jumpSpeed));

        for (int i  = 1; i < _numberOfSegments; i++)
        {
            //setting the time offset
            float timeOffset = i * Time.fixedDeltaTime * _curveLength;

            // calulate gravity offset based on rb
            Vector2 gravityOffset = 0.5f * Physics2D.gravity * _frogGravity * Mathf.Pow(timeOffset, 2);

            _segments[i] = _segments[0] + startvelocity * timeOffset + gravityOffset;
            _lineRenderer.SetPosition(i, _segments[i]);
        }
    }
}
