using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpPower;

    private float direction;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(jump)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jump = false;
        }

        if(direction == 0)
            return;
            
        float newSpeed = Mathf.Abs(rb.velocity.x + (direction * acceleration) * Time.deltaTime);
        rb.velocity = newSpeed <= maxSpeed 
            ? new Vector3(direction * newSpeed, rb.velocity.y, 0)
            : new Vector3(direction * maxSpeed, rb.velocity.y, 0);
    }

    public void Move(float horizontal) => direction = horizontal;
    public void Jump() => jump = true;
}