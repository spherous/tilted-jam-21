using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    public float speed;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(velocity * speed);
    }

    public void Move(float horizontal)
    {
        velocity = new Vector2(horizontal, velocity.y);
    }
}