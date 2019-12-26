using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class Timer : MonoBehaviour
{
    [SerializeField] private float mTime;

    void OnEnable()
    {
        StartCoroutine(TimeOut());
    }

    private IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(mTime);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
