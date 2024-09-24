using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 5f;
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
        InvokeRepeating("MovePlatform", 0f, 0.02f);
    }

    void MovePlatform()
    {
        if (movingForward)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            {
                movingForward = false;
            }

        }
    }
}