using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class MainUIController : MonoBehaviour
{
    private static int mUIMoveHash = Animator.StringToHash("Move");
    [SerializeField] Animator[] mWindowAnims;

    public void MoveWindow(int id)
    {
        mWindowAnims[id].SetTrigger(mUIMoveHash);
    }
}
