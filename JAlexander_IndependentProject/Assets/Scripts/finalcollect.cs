using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalcollect : MonoBehaviour
{
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


            Debug.Log("Game Over");

           
            gameObject.SetActive(false);
        }
    }


}
