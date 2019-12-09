using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class GemController : MonoBehaviour
{
    public const int MAX_GEM_COUNT = 3;
    [SerializeField] private int mSheetCount = 5;
    [SerializeField] private SpriteRenderer mGem;
    [SerializeField] private Sprite[] mGemSprite;
    private double mCurrentHP, mMaxHP;
    private int mCurrentPhase, mStartIndex;

    void Awake()
    {
        mGemSprite = Resources.LoadAll<Sprite>("Gem");
    }

    public void GetNewGem(int id)
    {
        mStartIndex = id * mSheetCount;
        mGem.sprite = mGemSprite[id * mSheetCount];
        mCurrentPhase = 0;
    }

    public void AddProgress(double value)
    {
        mCurrentHP += value;
        if (mCurrentHP >= mMaxHP * 0.2F * mCurrentPhase)
        {
            if (mCurrentPhase > 5)
            {
                // Clear
                return;
            }
            mCurrentPhase++;
            mGem.sprite = mGemSprite[mStartIndex + mCurrentPhase];
        }
    }
}