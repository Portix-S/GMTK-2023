using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
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
        rb = GetComponent<Rigidbody>();
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
                animator.speed *= 2; 
                moveSpeed *= 2f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.speed /= 2;
                moveSpeed /= 2f;
            }

            moveDirection = new Vector3(movementX, 0, movementY);

            if(movementY < 0f || movementX != 0)
                animator.SetInteger("isMoving", -1);
            else if(movementY > 0f)
                animator.SetInteger("isMoving", 1);
            else
                animator.SetInteger("isMoving", 0);

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
