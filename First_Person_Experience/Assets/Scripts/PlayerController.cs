using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    public float speed;
 
    public float jumpForce;
    public float gravityLimit;
    public float gravity;
    public float gravityMultiplier;
 
    public int JumpsAvailable = 1;
 
    public float cameraSpeed; // higher number = quicker reaction to rotation
    Vector2 inputs;
 
    public GameObject cam;
    public GameObject PlayerHead;
 
    public bool isSprinting;
    public bool isCrouching;
    private Vector3 smallScale;
    private Vector3 playerScale;
 
    public CharacterController controller;
 
    void Awake()
    {
        playerScale = new Vector3(1,1,1);
        smallScale = new Vector3(1,0.75f,1);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isSprinting = false;
        isCrouching = false;
    }
 
    // Update is called once per frame
    void Update()
    {
       Movement();
       Rotation();
       jump();
       // Crouch();
    }
 
    void Movement()
    {
       inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       Vector3 movement = new Vector3(inputs.x, gravity, inputs.y);
       movement = Quaternion.Euler(0, cam.transform.eulerAngles.y,0) * movement;
       controller.Move(movement * speed * Time.deltaTime);
 
       if(Input.GetKey(KeyCode.LeftShift) && isCrouching == false)
       {
            speed = 7;
            isSprinting = true;
       }
       else if(Input.GetKey(KeyCode.LeftControl) && isSprinting == false)
       {
            isCrouching = true;
            speed = 2;
            gameObject.transform.localScale = smallScale;
       }
       else
       {
            isCrouching = false;
            isSprinting = false;
            speed = 5;
            gameObject.transform.localScale = playerScale;
       }
    }
 
    void Rotation()
    {
        PlayerHead.transform.rotation = Quaternion.Slerp(PlayerHead.transform.rotation, cam.transform.rotation, cameraSpeed * Time.deltaTime);
    }
 
    void jump()
    {
        if (gravity < gravityLimit)
        {
            gravity = gravityLimit;
        }
        else
        {
            gravity -= Time.deltaTime * gravityMultiplier;
        }
 
        if(Input.GetButtonDown("Jump") && JumpsAvailable > 0 && isCrouching == false)
        {
            gravity = Mathf.Sqrt(jumpForce);
            JumpsAvailable--;
        }
        if(controller.isGrounded)
        {
            JumpsAvailable = 1;
        }
    }
}