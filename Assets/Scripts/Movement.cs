using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Animations")]
    public Animator animator;
    public bool isRunning = false;

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public bool canMove = true;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        if(canMove)
            MovePlayer();

        if (Input.GetKey(KeyCode.LeftShift))
            isRunning = true;
        else
            isRunning = false;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.4f, groundMask);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isRunning)
            moveSpeed = 5f;
        else
            moveSpeed = 3.5f;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        isRunning = false;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > 0.1 && isRunning == false)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);

        }
        else if(flatVel.magnitude > 0.1 && isRunning == true)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", false);
        }

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
