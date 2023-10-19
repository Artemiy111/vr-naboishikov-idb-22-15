using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     private Rigidbody rb;
//     [SerializeField] private float speed = 5.0f;
//     [SerializeField] private float jumpForce = 500.0f;
//     [SerializeField] private float mouseSensitivity = 100.0f;
//     private bool isGrounded;
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         float moveHorizontal = Input.GetAxis("Horizontal");
//         float moveVertical = Input.GetAxis("Vertical");
//         Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
//         rb.AddForce(movement * speed, ForceMode.Acceleration);

//         bool isJump = Input.GetButtonDown("Jump");
//         bool canJump = isJump && isGrounded;
//         rb.AddForce(Convert.ToInt16(canJump) * jumpForce * Vector3.up, ForceMode.Force);

//     }

//     private void OnCollisionEnter(Collision other)
//     {
//         if (other.gameObject.name == "Floor")
//         {
//             isGrounded = true;
//         };
//     }

//     private void OnCollisionExit(Collision other)
//     {
//         if (other.gameObject.name == "Floor")
//         {
//             isGrounded = false;
//         }
//     }
// }


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    // [SerializeField] Transform groundCheck;
    // [SerializeField] float groundDistance = 0.4f;
    // [SerializeField] LayerMask groundMask;

    Vector3 playerVelocity;

    // bool isGrounded;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void ProcessMovement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(moveDirection * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        Debug.Log(controller.isGrounded);
        Debug.Log(playerVelocity);
        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            // controller.Move(Vector3.up * jumpHeight * Time.deltaTime);
        }
    }
    // Update is called once per frame
    // void Update()
    // {
    //     //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
    //     isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    //     if (isGrounded && velocity.y < 0)
    //     {
    //         velocity.y = -2f;
    //     }

    //     float x = Input.GetAxis("Horizontal");
    //     float z = Input.GetAxis("Vertical");

    //     //right is the red Axis, foward is the blue axis
    //     Vector3 move = transform.right * x + transform.forward * z;

    //     controller.Move(move * speed * Time.deltaTime);

    //     //check if the player is on the ground so he can jump
    //     if (Input.GetButtonDown("Jump") && controller.isGrounded)
    //     {
    //         //the equation for jumping
    //         velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    //     }

    //     velocity.y += gravity * Time.deltaTime;

    //     controller.Move(velocity * Time.deltaTime);
    // }
}
