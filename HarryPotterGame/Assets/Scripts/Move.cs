using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;
    private Animator animator;
    private bool isJumping;
    private bool isGrounded;
    private int jumpCount = 0;

    public Animator GetAnim
    {
        get
        {
            return animator;
        }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimGroundCheck();
        TakeInput();
        OnGroundCheck();
    }

    private void TakeInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, Mathf.Clamp((-speed) * 100 * Time.deltaTime, -15f, 0f));
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 179.99f, 0f), turnSpeed * Time.deltaTime);
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, Mathf.Clamp((speed) * 100 * Time.deltaTime, 0f, 15f));
            //transform.rotation = Quaternion.Euler(0f, -360f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 359.99f, 0f), turnSpeed * Time.deltaTime);
            animator.SetBool("Walk", true);
        }
        else
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);

        }
        if (jumpCount > 0 && !OnGroundCheck())
        {
            Jump();
        }
        if (OnGroundCheck())
        {
            Jump();
        }
        else
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsGrounded", false);
            animator.SetBool("IsFalling", true);
        }


    }

    private bool OnGroundCheck()
    {
         bool hit = false;
         for (int i = 0; i < rayStartPoints.Length; i++)
         {
             hit = Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.25f);
             Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.25f, Color.red);
         }

         if (hit)
         {
             return true;
         }
         else
         {
             return false;
         } 
        //return Physics.CheckSphere(rayStartPoints[0].position, 1f);
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rigidbody.velocity = new Vector3(0f, Mathf.Clamp((jumpPower) * Time.deltaTime, 0f, 250f), 0f);
            isJumping = true;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsGrounded", false);
            isGrounded = false;
            jumpCount++;
        }
    }
    private void AnimGroundCheck()
    {
        if (OnGroundCheck())
        {
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
            isJumping = true;
            animator.SetBool("IsFalling", true);
        }
    }
}
