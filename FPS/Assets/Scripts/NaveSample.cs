using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#pragma warning disable CS0649
public class NaveSample : MonoBehaviour
{
    private NavMeshAgent mAgent;
    [SerializeField] private Transform mPos1, mPos2;
    private bool mbToPos1;

    void Awake()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mbToPos1 = true;
    }

    void Update()
    {
        if (mAgent.remainingDistance == 0)
        {
            if (mbToPos1)
            {
                mAgent.SetDestination(mPos1.position);
            }
            else
            {
                mAgent.SetDestination(mPos2.position);
            }
            mbToPos1 = !mbToPos1;
        }
    }
}
