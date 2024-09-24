using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class jump : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGroundStatus();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumping!");
        }
    }

    void CheckGroundStatus()
    {
        // Cast a ray downwards from the player's position
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            isGrounded = true;
            Debug.Log("Grounded!");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Not Grounded!");
        }
    }

}
