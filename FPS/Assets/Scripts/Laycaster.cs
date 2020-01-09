using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laycaster : MonoBehaviour
{
    private Camera mMainCamera;

    void Start()
    {
        mMainCamera = Camera.main;
    }

    public void Cast()
    {
        //Random.insideUnitCircle
        Vector3 nearPos = mMainCamera.ScreenToWorldPoint(new Vector3(0, 0, mMainCamera.nearClipPlane));
        Vector3 farPos = mMainCamera.ScreenToWorldPoint(new Vector3(0, 0, mMainCamera.farClipPlane));

        if (Physics.Raycast(nearPos, farPos - nearPos, out RaycastHit hit))
        {
            transform.LookAt(hit.point, hit.normal); //hit.normal => 법선백터
        }
    }
}
