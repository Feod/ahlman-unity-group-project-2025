using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragscript : MonoBehaviour
{
    public bool dragging = false;
    public Vector3 offset;


    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
