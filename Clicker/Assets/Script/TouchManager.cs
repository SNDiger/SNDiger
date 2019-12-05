using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class TouchManager : MonoBehaviour
{
    [SerializeField] private Camera mTouchCamera;
    [SerializeField] private GameObject mDummy;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GenerateRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 3))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(hit.point);
                    GameObject dummy = Instantiate(mDummy);
                    dummy.transform.position = hit.point;
                }
            }
        }
    }

    public Ray GenerateRay(Vector3 screenPos)
    {
        Vector3 nearPlane = mTouchCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, mTouchCamera.nearClipPlane));
        Vector3 farPlane = mTouchCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, mTouchCamera.farClipPlane));

        return new Ray(nearPlane, farPlane - nearPlane);
    }
}
