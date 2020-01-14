using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class DragBasic : MonoBehaviour
{
    [SerializeField] private float mCameraDistance;

    void OnMouseDrag()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mCameraDistance);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }

    void OnMouseEnter()
    {
        Debug.Log("MouseEnter");
    }

    void OnMouseDown()
    {
        Debug.Log("MouseDown");
    }
}
