using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 moveDirection;

    [Header("Stats")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float movementX;
    [SerializeField] float movementY;
    private bool isFacingLeft;
    public bool isOnMenu;
    private bool isOnPauseMenu;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    public void PauseMenu(bool onPauseMenu)
    {
        isOnPauseMenu = onPauseMenu;
    }


    // Update is called once per frame
    private void Update()
    {
        // Better code, but not as snappy as I wanted
        /*   
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
        //*/

        // Player Movement
        if (!isOnMenu && !isOnPauseMenu)
        {
            movementX = 0f;
            movementY = 0f;
            if (Input.GetKey(KeyCode.W))
                movementY = 1f;
            if (Input.GetKey(KeyCode.S))
                movementY = -1f;
            if (Input.GetKey(KeyCode.D))
                movementX = 1f;
            if (Input.GetKey(KeyCode.A))
                movementX = -1f;

            // Running Logic
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed *= 2f;
                animator.SetBool("isRunning", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed /= 2f;
                animator.SetBool("isRunning", false);
            }

            moveDirection = new Vector3(movementX, movementY).normalized;

            // Animations
            if (movementX != 0f || movementY != 0f)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);

            // Handling if needs to rotate player left/right
            if (movementX < 0f && !isFacingLeft)
            {
                isFacingLeft = true;
                FlipPlayer();
            }
            else if (movementX > 0f && isFacingLeft)
            {
                isFacingLeft = false;
                FlipPlayer();
            }
        }
    }

    private void FlipPlayer()
    {
        // Rotate around y axis
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        // Adds velocity to rigidbody decide how to move
        if(!isOnMenu)
            rb.velocity = moveDirection * moveSpeed;
    }
}
