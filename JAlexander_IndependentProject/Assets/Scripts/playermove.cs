using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playermove : MonoBehaviour
{
    public float speed = 5.0f;
   
 private Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;
    private bool isGrounded = true;
    Animator animator;

    public AudioClip footstepSound;
    public AudioClip jumpSound;

    private AudioSource asplayer;

    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        animator = GetComponent<Animator>();


        asplayer = GetComponent<AudioSource>();
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayGame();

        }
    }


    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(4);
    }

    void Update()
    {


        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;

        if (hVal != 0 || vVal != 0)
        {
            movement = new Vector3(hVal, 0, vVal) * speed * Time.deltaTime;
            transform.Translate (movement);
            animator.SetBool("isrunning", true);
            asplayer.PlayOneShot(footstepSound, .5f);
        }
        else
        {
            animator.SetBool("isrunning", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump");
            asplayer.PlayOneShot(jumpSound, 1f);
        }
    }

    


}