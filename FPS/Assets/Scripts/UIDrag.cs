using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler,IPointerClickHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPos.z = 100;
        transform.position = worldPos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Point Click");
    }
}
