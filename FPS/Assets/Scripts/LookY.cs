using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    private Vector3 mLastMousePos;

    void Start()
    {
        mLastMousePos = Input.mousePosition;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - mouseY, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}