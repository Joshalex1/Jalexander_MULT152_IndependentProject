using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5.0f;
   
 private Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;
    private bool isGrounded = true;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
    // Update is called once per frame



    void Update()
    {


        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hVal, 0, vVal) * speed * Time.deltaTime;

        transform.Translate(movement);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


}