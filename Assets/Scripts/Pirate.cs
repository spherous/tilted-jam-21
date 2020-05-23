using System;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpPower;
    
    private float direction;

    private bool grounded = false;
    private bool jump = false;
    private bool jumpLock = false;
    private bool airJump = false;
    private bool airJumpLock = false;

    private float jumpLockDelaySeconds = 0.16f;
    private float jumpLockDelayed = 0;

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
            // Check if we are becoming grounded
            grounded = CheckGrounded();
            // if so, reset locks
            if(grounded)
            {
                airJump = false;
                airJumpLock = false;
                jumpLock = false;
                jumpLockDelayed = 0;
            }
            else if(jumpLockDelayed < jumpLockDelaySeconds)
                jumpLockDelayed += Time.deltaTime;
            else if(jumpLockDelayed >= jumpLockDelaySeconds && !jumpLock)
                jumpLock = true;
        }
        else
        {
            grounded = CheckGrounded();
            // left platform
            if(!grounded)
            {
                // jumpLockDelayed++;
            }
        }
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
        else if(!grounded && !airJump && !airJumpLock)
            airJump = true;
    }
}