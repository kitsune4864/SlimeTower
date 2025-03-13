using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slime_Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float jumpForce;
    [SerializeField] 
    private int maxJumpForce;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private float gravityForce = -9.81f;
    private Transform cameraTransform;
    private Animator animator;
    [SerializeField]
    private TMP_Text slimeJumpPower;
    RaycastHit hit;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        cameraTransform = Camera.main.transform;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void Update()
    {
        SlimeJumpDetect();
        SlimeGroundDetect();
    }

    void FixedUpdate()
    {
        SlimeMove();
    }

    private void SlimeMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = (cameraTransform.forward * v + cameraTransform.right * h);
        dir = Vector3.ProjectOnPlane(dir, Vector3.up).normalized;// ProjectOnPlane => dir의 방향을 수평으로 유지(카메라가 수직이 되었을때)
        
        //rb.linearVelocity = dir * moveSpeed;
        Vector3 velocity = new Vector3(dir.x * moveSpeed, rb.linearVelocity.y, dir.z * moveSpeed);
        
        
        if (isJumping)
        {
            velocity.y = jumpForce;
            isJumping = false;
            jumpForce = 4;
            dir.x = 0;
            
        } // 점프 판별 코드

        if (!isGrounded)
        {
            velocity.y = Mathf.Max(rb.linearVelocity.y + gravityForce * Time.fixedDeltaTime);
        }
        
        bool isCollidingFront = Physics.Raycast(transform.position, dir, out hit, 0.6f, ~0, QueryTriggerInteraction.Ignore);
        if (isCollidingFront)
        {
            //Debug.Log(hit.collider.gameObject.name);
            velocity.x = 0;
            velocity.z = 0;
        }
        
        
        rb.linearVelocity = velocity;

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

    private void SlimeJumpDetect() //Jump상태를 제어하는 메소드
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpForce < maxJumpForce)
            {
                jumpForce +=  Time.deltaTime * 2;
            }
            animator.SetBool("IsReady", true);
            slimeJumpPower.text = jumpForce.ToString();
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            animator.SetBool("IsReady", false);
            animator.SetTrigger("IsJumping");
           
        }
    }

    private void SlimeGroundDetect()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1f);
    }
}
