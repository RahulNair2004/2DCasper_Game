using UnityEngine;

public class WallJumpController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float wallCheckDistance = 0.5f;
    public LayerMask wallLayer;

    private Rigidbody rb;
    private bool isTouchingWall;
    private bool isWallJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for wall
        isTouchingWall = Physics.Raycast(transform.position, transform.right, wallCheckDistance, wallLayer)
                      || Physics.Raycast(transform.position, -transform.right, wallCheckDistance, wallLayer);

        if (isTouchingWall && !isWallJumping)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingWall && !isWallJumping)
        {
            WallJump();
        }
    }

    void WallJump()
    {
        isWallJumping = true;
        Vector3 jumpDirection = isTouchingWall ? Vector3.up : transform.forward; // Jump up if touching wall, else jump forward
        rb.velocity = jumpDirection * jumpForce;
        Invoke("ResetWallJump", 0.5f); // Reset wall jump after a delay
    }

    void ResetWallJump()
    {
        isWallJumping = false;
    }
}


