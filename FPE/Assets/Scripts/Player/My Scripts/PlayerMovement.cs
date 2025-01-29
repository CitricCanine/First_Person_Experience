using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    public float moveSpeed;
    public float speedSprint;

    public float accelleration;
    public bool ifSprint;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    bool activeLight;

    public GameObject flashLight;
    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ifSprint = false;
        readyToJump = true;
        activeLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        // FlashLight();
        MyInput();
        SpeedControl();
        Quit();
    
    
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        // drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calc move direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ifSprint = true;
            if (moveSpeed < speedSprint)
            {
                moveSpeed += Time.deltaTime * accelleration;
            }
        }
        else
        {
            ifSprint = false;
            if (moveSpeed > 7.099999f)
            {
                moveSpeed -= Time.deltaTime * accelleration;
            }
        }

        if(grounded)
        {
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit vel if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVeled = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVeled.x, rb.velocity.y, limitVeled.z);
        }
    }

    private void Jump()
    {
        // reset Y velocity to zero so you have consistent jump heights
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }
    private void ResetJump()
    {
        readyToJump = true;
    }
    void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && activeLight == false)
        {
            flashLight.SetActive(true);
            activeLight = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && activeLight == true)
        {
           flashLight.SetActive(false); 
           activeLight = false;
       }
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
