using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;

    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude != maxSpeed)
        {
            rb.AddForce(new Vector3(direction, 0, 0) * acceleration);
        }
    }

    public void Move(float horizontal) => direction = horizontal;
}