﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private double mGold;
    public double Gold { get { return mGold; } set { mGold = value; } }
    private int mStage;
    [SerializeField] private GemController mGem;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        int id = Random.Range(0, GemController.MAX_GEM_COUNT);
        mGem.GetNewGem(id);
    }

    public void Touch()
    {
        if(mGem.AddProgress(1))
        {
            int id = Random.Range(0, GemController.MAX_GEM_COUNT);
            mGem.GetNewGem(id);
        }
    }
}
