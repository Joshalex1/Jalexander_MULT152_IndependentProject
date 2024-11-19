using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ARTIFACTS : MonoBehaviour
{
    public GameObject[] artifacts;
    public GameObject door; // Reference to the door GameObject 
    public ParticleSystem collectEffect;
    public TextMeshProUGUI artifactCounterText; // Reference to the TextMeshProUGUI component

    private int collectedCount = 0;

    void Start()
    {
        UpdateArtifactCounter();
    }

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
        UpdateArtifactCounter();
        CheckArtifacts();
    }

    void UpdateArtifactCounter()
    {
        artifactCounterText.text = "Artifacts Collected: " + collectedCount;
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
        Destroy(door); // Destroy the door GameObject
    }
}
