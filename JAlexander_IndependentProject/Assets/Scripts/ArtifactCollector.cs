using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactCollector : MonoBehaviour
{
    public GameObject[] artifacts;
    public GameObject door; // Reference to the door GameObject 
    private int collectedCount = 0;
    public ParticleSystem collectEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artifact"))
        {
            CollectArtifact(other.gameObject);

            if (collectEffect != null)
            {
                ParticleSystem effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }
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
