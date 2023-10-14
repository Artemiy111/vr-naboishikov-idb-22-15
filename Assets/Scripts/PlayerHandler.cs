using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    private Rigidbody rb;
    public UnityEvent onCollisionEnter;
    private float speed = 5.0f;
    private float jumpForce = 500.0f;
    private bool isGrounded;
    public int countCollision;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        onCollisionEnter.AddListener(foo);
    }

    private void Update()
    {



        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        rb.AddForce(movement * speed, ForceMode.Acceleration);

        bool isJump = Input.GetButtonDown("Jump");
        bool canJump = isJump && isGrounded;
        rb.AddForce(Convert.ToInt16(canJump) * Vector3.up * jumpForce, ForceMode.Force);
    }

    private void foo()
    {
        Debug.Log("Foo");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Floor")
        {
            isGrounded = true;
            return;
        };

        countCollision--;
        onCollisionEnter.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Floor")
        {
            isGrounded = false;
        }
    }
}
