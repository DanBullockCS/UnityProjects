// Controls the WASD/Arrow Key movement of the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5.0f;

    private CharacterController charController;
    
    private float sprint;
    private float gravity = -9.81f * 2f;
    private float jumpHeight = 1f;

    public Transform groundCollider;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    private bool isGrounded;

    void Start() {
        charController = GetComponent<CharacterController>();
    }

    void Update() {
        // Adding Sprinting
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift);
        if (isShiftKeyDown) {
            sprint = Mathf.Sqrt(10.0f);
        } else {
            sprint = 1;
        }

        // Checking player collision with ground using a sphere
        isGrounded = Physics.CheckSphere(groundCollider.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f; // -2 to force player down to the ground as opposed to using 0f
        }

        // WASD Input
        float x = Input.GetAxis("Horizontal") * sprint;
        float z = Input.GetAxis("Vertical") * sprint;

        Vector3 moveDirectionVector = transform.right * x + transform.forward * z;

        // Move the character controller in using the move vector (Simplemove ignores Y axis)
        charController.Move(moveDirectionVector * moveSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Crouching
        if (Input.GetKey(KeyCode.LeftControl)) {
            charController.height = 1.0f;
        } else {
            // Gradually add back the height until it's back to 2.25f (Original player height)
            if (charController.height <= 2.25f) {
                charController.height += 0.05f;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime); // Using 1/2*gravity*time^2 (Gravity formula)
    }
}
