// Controls the WASD/Arrow Key movement of the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5.0f;

    private CharacterController charController;
    private float sprint;

    void Start() {
        charController = GetComponent<CharacterController>();
    }

    void Update() {
        // Sprinting for easier traversal of terrain.
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift);
        if (isShiftKeyDown) {
            sprint = Mathf.Sqrt(10.0f);
        } else {
            sprint = 1;
        }

        // WASD Input
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * sprint;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * sprint;

        Vector3 moveDirectionVector = transform.forward * vertical + transform.right * horizontal;

        // Move the character controller in using the move vector (Simplemove ignores Y axis)
        charController.SimpleMove(moveDirectionVector);
    }
}
