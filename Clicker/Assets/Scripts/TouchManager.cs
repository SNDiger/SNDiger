﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class TouchManager : MonoBehaviour
{
    [SerializeField] private Camera mTouchCamera;
    [SerializeField] private GameObject mDummy;
    [SerializeField] private EffectPool mEffectPool;
 
    public Ray GenerateRay(Vector3 screenPos)
    {
        Vector3 nearPlane = mTouchCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, mTouchCamera.nearClipPlane));
        Vector3 farPlane = mTouchCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, mTouchCamera.farClipPlane));
        return new Ray(nearPlane, farPlane - nearPlane);
    }

    public bool GetTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = GenerateRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Timer effect = mEffectPool.GetFromPool(0);
                        effect.transform.position = hit.point;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GenerateRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Timer effect = mEffectPool.GetFromPool(0);
                    effect.transform.position = hit.point;
                }
            }
            GameController.Instance.Touth();
        }
#endif
        if (GetTouch())
        {
            GameController.Instance.Touth();
        }
    }
}