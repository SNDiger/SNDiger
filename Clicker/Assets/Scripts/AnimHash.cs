using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public static class AnimHash
{
    public static readonly int Move = Animator.StringToHash("IsMove");
    public delegate void TwoIntPramCallback(int a, int b);
    public delegate void VoidCollback();
}
