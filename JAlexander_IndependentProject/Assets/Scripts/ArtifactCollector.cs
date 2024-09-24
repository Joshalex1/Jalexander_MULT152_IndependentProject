using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactCollector : MonoBehaviour
{
    public GameObject[] artifacts;
    public GameObject door; // Reference to the door GameObject 
    private int collectedCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artifact"))
        {
            CollectArtifact(other.gameObject);
        }
    }

    void CollectArtifact(GameObject artifact)
    {
        artifact.SetActive(false);
        collectedCount++;
        CheckArtifacts();
    }

    void CheckArtifacts()
    {
        if (collectedCount == artifacts.Length)
        {
            UnlockNewArea();
        }
    }

    void UnlockNewArea()
    {
        Destroy(door); // Destroy the door GameObject  } 
    }
}
