﻿// Controls the characters movements (jumping, running etc)
// Retrieved From: https://github.com/randyfortier/CSCI4160U_Examples/blob/master/03a_2D_Levels/Assets/CharacterController2D.cs
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {

    [Header("General")]
    [SerializeField] private float movementSpeed = 5f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private LayerMask groundLayers;
    public float speed = 0.0f;

    [Header("Jumping")]
    [SerializeField] private bool canAirControl = true;
    [SerializeField] private float jumpForce = 235f;
    [SerializeField] private Transform groundPosition;
    public bool isGrounded;

    public bool isFacingRight = true;

    const float groundedRadius = .1f;
    const float ceilingRadius = .1f;
    
    private Rigidbody2D rigidBody;
    private Vector3 velocity = Vector3.zero;

    [Header("Events")]
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null) {
            OnLandEvent = new UnityEvent();
        }
    }

    private void FixedUpdate() {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // find any ground layer colliders closer than the ground position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPosition.position, groundedRadius, groundLayers);
        //Debug.Log("Overlapping colliders: " + colliders.Length);
        for (int i = 0; i < colliders.Length; i++) {
            // if any of the colliders are not the object iself, it must be the ground
            if (colliders[i].gameObject != gameObject) {
                // we are now grounded
                isGrounded = true;

                // if we were not grounded before, but now are, generate the landed event
                if (!wasGrounded) {
                    OnLandEvent.Invoke();
                }
            }
        }
    }


    public void Move(float move, bool jump) {
        // only control the player if grounded or canAirControl is turned on
        if (isGrounded || canAirControl) {
            // what speed do we want to travel?
            Vector3 targetVelocity = new Vector2(move * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // apply smoothing to the speed
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);

            // export the speed
            speed = rigidBody.velocity.magnitude;

            if (move > 0 && !isFacingRight) {
                // flip the sprite horizontally when travelling left
                Flip();
            } else if (move < 0 && isFacingRight) {
                // flip the sprite horizontally when travelling left
                Flip();
            }
        }
        if (isGrounded && jump) {
            // add a vertical force to the player
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Flip() {
        // remember which way the sprite is facing
        isFacingRight = !isFacingRight;

        // multiply the player's x local scale by -1
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}