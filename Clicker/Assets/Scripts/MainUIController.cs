using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class MainUIController : MonoBehaviour
{
    private static int mUIMoveHash = Animator.StringToHash("Move");
    [SerializeField] private Animator[] mWindowAnims;
    [SerializeField] private Image mHPGaugeBar;

    public void MoveWindow(int id)
    {
        mWindowAnims[id].SetTrigger(mUIMoveHash);
    }

    public void ShowHPBar(float progress)
    {
        mHPGaugeBar.fillAmount = progress;
    }
    public void ShowHPBar(double currentHP, double maxHP)
    {
        double value = currentHP / maxHP;
        mHPGaugeBar.fillAmount = (float)value;
    }
}
