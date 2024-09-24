using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    

    void Update()
    {
        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");
       
        Vector3 movement = new Vector3(hVal, 0 , vVal) * speed * Time.deltaTime;

     transform.Translate(movement);




        if (Input.GetKeyDown(KeyCode.Space))

        {
            Vector3 jump = new Vector3(0, 3, 0);
            transform.Translate(jump);


        }


    }


}