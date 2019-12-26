using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class TextEffect : MonoBehaviour
{
    [SerializeField] private Text mText;

    public void ShowText(string data)
    {
        mText.text = data;
    }
}
