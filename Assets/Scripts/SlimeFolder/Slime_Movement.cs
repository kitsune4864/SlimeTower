using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slime_Movement : MonoBehaviour
{
   
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
    private bool isPlatformed;
    
    [SerializeField]
    private bool isJumping;
    
    [SerializeField] 
    private bool isFloating;
    
    [SerializeField]
    private float gravityForce = -9.81f;
    
    [SerializeField]
    private AudioSource slimeSound;
    
    [SerializeField]
    private AudioClip jumpSound;
    
    [SerializeField]
    private AudioClip collectSound;

    [SerializeField]
    private bool isRidding;
    
    private float hInput;
    
    private float vInput;
    
    private Rigidbody rb;
    
    private int jExcludeLayer = 0;
    
    private int jLayerMask;
    
    private int mExcludeLayer = 0;
    
    private int mLayerMask;
    
    private Transform cameraTransform;
    
    private Animator animator;
    
    RaycastHit hit;

    private void Awake()
    {
        jExcludeLayer = LayerMask.GetMask("Water", "Player");
        jLayerMask = ~jExcludeLayer;

        mExcludeLayer = LayerMask.GetMask("PushThing", "Collections");
        mLayerMask = ~mExcludeLayer;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        cameraTransform = Camera.main.transform;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        slimeSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SlimeJumpDetect();
        SlimeGroundDetect();
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        SlimeMove();
    }

    private void SlimeMove()
    {
        Vector3 dir = (cameraTransform.forward * vInput + cameraTransform.right * hInput).normalized;
        
        dir = Vector3.ProjectOnPlane(dir, Vector3.up).normalized;
        // ProjectOnPlane => dir의 방향을 수평으로 유지(카메라가 수직이 되었을때)
        
        Vector3 velocity = new Vector3(dir.x * moveSpeed, rb.linearVelocity.y, dir.z * moveSpeed);
        
        if (isJumping)
        {
            velocity.y = jumpForce;
            isJumping = false;
            jumpForce = 4;
            dir.x = 0;
            
        } // 점프 판별 코드

        if (!isGrounded && !isPlatformed && !isRidding)
        {
            velocity.y = Mathf.Max(rb.linearVelocity.y + gravityForce * Time.fixedDeltaTime );
        }
        
        Vector3 point2 = transform.position - Vector3.up * 0.2f;
        
        bool isCollidingFront = 
            Physics.CapsuleCast(transform.position, point2,
                0.2f, dir, out hit, 
                0.3f, mLayerMask, QueryTriggerInteraction.Ignore);
        if (isCollidingFront)
        {
            velocity.x = 0;
            velocity.z = 0;
        }
        
        rb.linearVelocity = velocity;
        
        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        } // 이동값이 0 이 아닐떄 캐릭터를 카메라 방향으로 회전
        
        if (Mathf.Approximately(hInput, 0f) && Mathf.Approximately(vInput, 0f))
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
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded || isPlatformed || isRidding)
            {
                if (jumpForce < maxJumpForce)
                {
                    jumpForce += Time.deltaTime * 3;
                }
                animator.SetBool("IsReady", true);
                isFloating = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isFloating)
        {
            isJumping = true;
            animator.SetBool("IsReady", false);
            animator.SetTrigger("IsJumping");
            isFloating = false;
            
            slimeSound.clip = jumpSound;
            slimeSound.Play();
        }
        
    }
    
    private void SlimeGroundDetect()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.7f, jLayerMask);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collections"))
        {
            slimeSound.clip = collectSound;
            slimeSound.PlayOneShot(collectSound, 1.0f);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isPlatformed = true;
        }

        if (other.gameObject.CompareTag("ShortCut"))
        {
            isRidding = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject)
        {
            isPlatformed = false;
        }

        if (other.gameObject.CompareTag("ShortCut"))
        {
            isRidding = false;
        }
    }

    
    
}
