using UnityEngine;

public class Slime_Falling : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravityMultiplier = 2f;
    [SerializeField] private float airControlMultiplier = 0.5f;
    private bool isGrounded;
    private Transform cameraTransform;
    private Animator animator;

    void Start()
    {
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
        ApplyGravity();
    }

    private void SlimeMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = (cameraTransform.forward * v + cameraTransform.right * h).normalized;
        dir.y = 0;

        // 공중에서는 이동 속도를 줄이기
        float currentMoveSpeed = isGrounded ? moveSpeed : moveSpeed * airControlMultiplier;
        rb.linearVelocity = new Vector3(dir.x * currentMoveSpeed, rb.linearVelocity.y, dir.z * currentMoveSpeed);

        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetBool("IsWalking", !(Mathf.Approximately(h, 0f) && Mathf.Approximately(v, 0f)));
    }

    private void SlimeJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
        }
    }

    private void ApplyGravity()
    {
        if (!isGrounded)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.fixedDeltaTime;
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
