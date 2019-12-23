using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class GoldUPEffect : MonoBehaviour
{
    [SerializeField] private Text mGoldText;

    public void ShowGoldText(string value)
    {
        mGoldText.text = value;
    }
}
