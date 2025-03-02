using System;
using Unity.VisualScripting;
using UnityEditor.Searcher;
using UnityEngine;

public class Slime_Movement : MonoBehaviour
{
    private CharacterController cc;
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField] 
    private float fallForce = 2f;
    [SerializeField] 
    private int maxJumpForce = 200;
    [SerializeField]
    private float chargeJumpForce;
    [SerializeField]
    private bool isGrounded;
    private Transform cameraTransform;
    private Animator animator;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        SlimeJump();
    }

    void FixedUpdate()
    {
        SlimeMove();
        
        SlimeFall();
    }

    private void SlimeMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = (cameraTransform.forward * v + cameraTransform.right * h);
        dir = Vector3.ProjectOnPlane(dir, Vector3.up).normalized;
        
        rb.linearVelocity = dir * moveSpeed;
        

        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        } // 이동값이 0 이 아닐떄 캐릭터를 카메라 방향으로 회전
        
        if (Mathf.Approximately(h, 0f) && Mathf.Approximately(v, 0f))
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }

    private void SlimeJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpForce < maxJumpForce)
            {
                jumpForce += 10 * Time.deltaTime;
            }
            animator.SetBool("IsReady", true);
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpForce = 100;
            
            animator.SetBool("IsReady", false);
            animator.SetTrigger("IsJumping");
        }
    }

    private void SlimeFall()
    {
        if (rb.linearVelocity.y <= 0)
        {
            rb.AddForce(Vector3.down * fallForce, ForceMode.Acceleration);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Structure"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
