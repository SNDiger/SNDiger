﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class MainUIController : MonoBehaviour
{
    public static MainUIController Instance;
    [SerializeField] private Animator[] mWindowAnims;
    [SerializeField] private GaugeBar mProgressBar;
    [SerializeField] private Text mGoldText;

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

    public void ShowGold(double value)
    {
        mGoldText.text = UnitBuilder.GetUnitStr(value);
    }

    public void ShowProgress(double current, double max)
    {
        //TODO calc Gauge progress float value
        float progress = (float)(current / max);
        ////hack build Gauge progress string
        //string progressString = progress.ToString("P0");
        string progressString = string.Format("{0} / {1}",
                                UnitBuilder.GetUnitStr(current),
                                UnitBuilder.GetUnitStr(max));
        mProgressBar.ShowGaugeBar(progress, progressString);
    }

    public void MoveWindow(int id)
    {
        mWindowAnims[id].SetTrigger(StaticValues.UIMove);
    }
}
