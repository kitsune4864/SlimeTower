using System;
using Unity.VisualScripting;
using UnityEditor.Searcher;
using UnityEngine;

public class Slime_Movement : MonoBehaviour
{
    private CharacterController cc;
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private bool isGrounded;
    private Transform cameraTransform;
    private Animator animator;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        SlimeMove();
        SlimeJump();
    }

    private void SlimeMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = (cameraTransform.forward * v + cameraTransform.right * h).normalized;
        dir.y = 0;
        
        rb.AddForce(dir * moveSpeed, ForceMode.Impulse);

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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
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
