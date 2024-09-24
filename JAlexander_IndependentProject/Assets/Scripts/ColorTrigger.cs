using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public Light triggerLight;
    private bool isActivated = false;
    private static int activatedCount = 0;
    public static int totalTriggers = 4;
    public GameObject door;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && !isActivated)
        {
            if (other.GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color)
            {
                ActivateTrigger(other.gameObject);
            }
        }
    }

    void ActivateTrigger(GameObject key)
    {
        isActivated = true;
        triggerLight.enabled = false;
        Destroy(key);
        activatedCount++;

        if (activatedCount == totalTriggers)
        {
            Destroy(door);
        }
    }
}
