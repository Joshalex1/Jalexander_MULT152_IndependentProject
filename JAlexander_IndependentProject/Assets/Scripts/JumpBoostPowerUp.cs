using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostPowerUp : MonoBehaviour
{
   
    public float jumpBoostMultiplier = 2f; 
    public AudioClip powerUpSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateJumpBoost(other));
        }
        Destroy(gameObject); 
    }

    private IEnumerator ActivateJumpBoost(Collider player)
    {
        playermove playerMove = player.GetComponent<playermove>();
        if (playerMove != null)
        {
            AudioSource audioSource = player.GetComponent<AudioSource>();
            if (audioSource != null && powerUpSound != null)
            {
                audioSource.PlayOneShot(powerUpSound, 1f);
            }

            playerMove.jumpForce *= jumpBoostMultiplier;
            yield return new WaitForSeconds(5);
            playerMove.jumpForce /= jumpBoostMultiplier;



        }


    }
}
