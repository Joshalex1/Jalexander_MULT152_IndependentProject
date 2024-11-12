using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUMPBOOST : MonoBehaviour
{
    public float jumpForceIncrease = 2f; // Amount to increase the jump force
    public AudioClip powerUpSound; // Sound to play when power-up is active
    public float powerUpDuration = 8f; // Duration of the power-up

    private bool hasPowerUp = false;
    private AudioSource audioSource;
    private playermove playerMove;

    private void Start()
    {
        playerMove = GetComponent<playermove>();
        audioSource = GetComponent<AudioSource>();

        // Ensure components are assigned
        if (!playerMove || !audioSource)
        {
            Debug.LogError("Required components are missing. Please ensure PlayerMove and AudioSource components are attached to the player object.");
            enabled = false; // Disable the script if components are missing
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
    }

    private IEnumerator PowerUpCountdown()
    {
        playerMove.jumpForce += jumpForceIncrease; // Increase jump force
        audioSource.PlayOneShot(powerUpSound, 1f); // Play power-up sound
        yield return new WaitForSeconds(powerUpDuration); // Wait for the duration
        playerMove.jumpForce -= jumpForceIncrease; // Reset jump force
        hasPowerUp = false;
    }

}


