using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class MainUIController : MonoBehaviour
{
    private static int mUIMoveHash = Animator.StringToHash("Move");
    [SerializeField] private Animator[] mWindowAnims;
    [SerializeField] private Image mGaugeBar;
    [SerializeField] private Text mGaugeBarText;

    public void MoveWindow(int id)
    {
        mWindowAnims[id].SetTrigger(mUIMoveHash);
    }

    public void ShowHPBar(float progress)
    {
        mGaugeBar.fillAmount = progress;
        string progressString = progress.ToString("P0");
        mGaugeBarText.text = progressString;
    }
    public void ShowHPBar(double current, double max)
    {
        float progress = (float)(current / max);
        string progressString = progress.ToString("P0");
        mGaugeBar.fillAmount = progress;
        mGaugeBarText.text = progressString;
    }
}
