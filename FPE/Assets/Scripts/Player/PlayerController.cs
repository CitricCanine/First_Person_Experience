using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Configure Player Variables")]
    public float speed;
    public float sprintSpeed;
    public float crouchSpeed;
    public int JumpsAvailable = 1;
    public float jumpForce;
    Vector2 inputs;


    [Header("Configure Gravity Variables")]
    public float gravityLimit;
    public float gravity;
    public float gravityMultiplier;


    [Header("Miscellaneous")] 
    public bool isSprinting;
    public bool isCrouching;
    private Vector3 smallScale;
    private Vector3 playerScale;
    public float cameraSpeed; // higher number = quicker reaction to rotation
    public string spawnPoint;
    public Animator bbox;
    bool activeLight;

    [Header("GameObjects")] 
    public GameObject playerBody;
    public GameObject playerCam;
    public CharacterController controller;
    public GameObject cam;
    public GameObject PlayerHead;
    public GameObject flashLight;


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
        activeLight = true;

    }
 
    // Update is called once per frame
    void Update()
    {
       Movement();
       Rotation();
       jump();
       //Crouch();
        FlashLight();

    }
 
    void Movement()
    {
       inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       Vector3 movement = new Vector3(inputs.x, gravity, inputs.y);//custom gravity and velocity
       movement = Quaternion.Euler(0, cam.transform.eulerAngles.y,0) * movement;//move in the direction you are looking at
       controller.Move(movement * speed * Time.deltaTime);//moves when you input the movement keys
 
       if(Input.GetKey(KeyCode.LeftShift) && isCrouching == false)
       {
            speed = sprintSpeed;
            isSprinting = true;
       }
       else if(Input.GetKey(KeyCode.LeftControl) && isSprinting == false)
       {
            isCrouching = true;
            speed = crouchSpeed;
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
            gravity = Mathf.Sqrt(jumpForce);//changes gravity to to jump force for a brief moment before gravity limit kicks in
            JumpsAvailable--;
            Debug.Log("JUMP");
        }
        if(controller.isGrounded)
        {
            JumpsAvailable = 1;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            StartCoroutine(ResetPos());
        }
    }

    public IEnumerator ResetPos ()
    {
        bbox.SetBool("out", true);

        transform.position = GameObject.Find(spawnPoint).transform.position;
        yield return new WaitForSeconds(.1f);
        controller.enabled = true;
    }

    public IEnumerator ResetOnDeath()
    {
        bbox.SetBool("out", false);
        
        controller.enabled = false;
        
        yield return new WaitForSeconds(1f);

        transform.position = GameObject.Find(spawnPoint).transform.position;
        
        yield return new WaitForSeconds(.1f);
        
        bbox.SetBool("out", true);

        controller.enabled = true;
    }

    public IEnumerator LoadNewScene(string levelName)
    {
        bbox.SetBool("out", false);

        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
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
}