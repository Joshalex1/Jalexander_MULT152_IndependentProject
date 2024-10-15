using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragdrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
   
    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
        
    }

    void OnMouseUp()
    {
        isDragging = false;
        
    }

    void Update()
    {
        if (isDragging)
        {

          Vector3 currentMousePos = GetMouseWorldPos() + offset;
            transform.position = new Vector3(transform.position.x, currentMousePos.y, currentMousePos.z);
         Debug.Log( offset);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

}

