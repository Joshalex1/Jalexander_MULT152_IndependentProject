using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalcollect : MonoBehaviour
{
    public ParticleSystem collectEffect; 
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
    
            playermove playermove = other.GetComponent<playermove>();
            if (playermove != null)
            {
                playermove.enabled = false;
            }


            CameraController CameraController = other.GetComponentInChildren<CameraController>();
            if (CameraController != null)
            {
                CameraController.enabled = false;
            }

            if (animator != null)
            {
                animator.enabled = false;
            }

            if (collectEffect != null)
            {
                ParticleSystem effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }

            Debug.Log("Game Over");

           
            gameObject.SetActive(false);
        }
    }


}
