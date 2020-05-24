using System;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask wallJumpCheckMask;
    
    private float direction;

    private bool grounded = false;
    private bool jump = false;
    private bool jumpLock = false;
    private bool airJump = false;
    private bool airJumpLock = false;

    private float jumpLockDelaySeconds = 0.16f;
    private float jumpLockDelayed = 0;

    private Vector3 leftOffset = new Vector3(-.52f, .5f, 0);
    private Vector3 rightOffset = new Vector3(.52f, .5f, 0);
    private Vector3 sideCheckColliderSize = new Vector3(.01f, .95f, 1f);

    private bool performWallJump = false;
    private bool wallJumpLeft = false;
    private bool wallJumpRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // if we were not grounded
        if(!grounded)
        {
            // Check if we are becoming grounded this frame
            grounded = CheckGrounded();
            // if so, reset locks
            if(grounded)
            {
                airJump = false;
                airJumpLock = false;
                jumpLock = false;
                jumpLockDelayed = 0;
                return;
            }
            // We are in the air
            // Give some leway on a jump
            else if(jumpLockDelayed < jumpLockDelaySeconds)
                jumpLockDelayed += Time.deltaTime;
            else if(jumpLockDelayed >= jumpLockDelaySeconds && !jumpLock)
                jumpLock = true;
            
            // Debug.Log(CanWallJump());
            CheckWallJumps();
        }
        // If we were on the ground
        else
        {
            // Check if we left a platform this frame
            grounded = CheckGrounded();
            if(!grounded)
            {    
            }
        }
    }

    private void CheckWallJumps()
    {
        wallJumpLeft = false;
        wallJumpRight = false;
        Collider[] rightSide = Physics.OverlapBox(transform.position + rightOffset, sideCheckColliderSize/2, Quaternion.identity, wallJumpCheckMask);
        Collider[] leftSide = Physics.OverlapBox(transform.position + leftOffset, sideCheckColliderSize/2, Quaternion.identity, wallJumpCheckMask);
        // Debug.Log($"right side: {rightSide.Length}, Left Side: {leftSide.Length}");
        // foreach(Collider c in rightSide)
        //     Debug.Log($"Right side hit {c.gameObject.name}");
        // foreach(Collider c in leftSide)
        //     Debug.Log($"Left side hit {c.gameObject.name}");
        
        if(rightSide.Length > 0)
            wallJumpRight = true;
        else if(leftSide.Length > 0)
            wallJumpLeft = true;
    }

    private void DoWallJump()
    {
        if(wallJumpRight)
            rb.velocity = new Vector3(-.5f, .5f, 0) * jumpPower/10;
            // rb.AddForce(new Vector3(.5f, .5f, 0) * jumpPower, ForceMode.Impulse);
        else if(wallJumpLeft)
            rb.velocity = new Vector3(.5f, .5f, 0) * jumpPower/10;
            // rb.AddForce(new Vector3(.5f, .5f, 0) * jumpPower, ForceMode.Impulse);
        
    }

    private bool CheckGrounded()
    {
        if(Physics.Raycast(new Ray(transform.position + (Vector3.up * 0.001f), -Vector3.up), out RaycastHit raycastHit, Mathf.Infinity) && raycastHit.distance >= .01f)
            return false;
        else
            return true;
    }

    private void FixedUpdate()
    {
        if(jump)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jump = false;
            jumpLock = true;
        }
        if(airJump)
        {
            rb.AddForce(Vector3.up * jumpPower * 0.75f, ForceMode.Impulse);
            airJump = false;
            airJumpLock = true;
        }

        if(performWallJump)
        {
            DoWallJump();
            airJump = false;
            airJumpLock = false;
            performWallJump = false;
        }

        if(direction == 0)
            return;
            
        float newSpeed = Mathf.Abs(rb.velocity.x + (direction * acceleration) * Time.deltaTime);
        rb.velocity = newSpeed <= maxSpeed 
            ? new Vector3(direction * newSpeed, rb.velocity.y, 0)
            : new Vector3(direction * maxSpeed, rb.velocity.y, 0);
    }

    public void Move(float horizontal) => direction = horizontal;
    public void Jump()
    {
        if(!jump && !jumpLock)
            jump = true;
        else if(wallJumpRight || wallJumpLeft)
            performWallJump = true;
        else if(!grounded && !airJump && !airJumpLock)
            airJump = true;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawCube(transform.position + rightOffset, sideCheckColliderSize);
        Gizmos.DrawCube(transform.position + leftOffset, sideCheckColliderSize);
    }
}