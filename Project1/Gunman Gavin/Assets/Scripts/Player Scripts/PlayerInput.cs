// Originally Retrieved From: https://github.com/randyfortier/CSCI4160U_Examples/blob/master/03a_2D_Levels/Assets/PlayerInput.cs
// Controls Player Input.

using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour {
    public float runSpeed = 50f;
    public Transform firePt;
    public GameObject bulletLeftPrefab;
    public GameObject bulletRightPrefab;

    private CharacterController2D controller;
    private Animator animator;

    private float horizontalMove = 0f;
    private bool jumping = false;

    void Start() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jumping = true;
        }
        if (Input.GetButtonDown("Fire1")) {
            if (animator.GetBool("hasGun") == true) {
                Shoot();
            }
        } else if (Input.GetButtonDown("Fire2")) {
            animator.SetTrigger("punch");
        }

        animator.SetFloat("Speed", controller.speed);
        animator.SetBool("Jumping", !controller.isGrounded);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jumping);
        jumping = false;
    }

    void Shoot() {
        // Shooting logic
        if (gameObject.transform.localScale.x == 1) {
            Instantiate(bulletRightPrefab, firePt.position, firePt.rotation);
        } else if(gameObject.transform.localScale.x == -1) {
            Instantiate(bulletLeftPrefab, firePt.position, firePt.rotation);
        }

    }
}