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
        Debug.Log("Trigger entered by: " + other.name);
        if (!isActivated && other.CompareTag(gameObject.tag))
        {
            Debug.Log("Tag matched: " + other.tag);
            ActivateTrigger(other.gameObject);
        }
        else
        {
            Debug.Log("Tag did not match or already activated.");
        }
    }

    void ActivateTrigger(GameObject key)
    {
        isActivated = true;
        triggerLight.enabled = false;
        Destroy(key);
        activatedCount++;
        Debug.Log("Activated count: " + activatedCount);

        if (activatedCount == totalTriggers)
        {
            Debug.Log("All triggers activated. Destroying door.");
            Destroy(door);
        }
    }
}
