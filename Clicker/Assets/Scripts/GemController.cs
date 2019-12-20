using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#pragma warning disable CS0649
public class GemController : MonoBehaviour
{
    public const int MAX_GEM_COUNT = 3;
    [SerializeField] private int mSheetCount = 5;
    [SerializeField] private SpriteRenderer mGem;
    [SerializeField] private Sprite[] mGemSprite;
    [SerializeField] private EffectPool mEffectPool;
    [SerializeField] private float mHPBase = 10, mHPWeight = 1.4F, 
                                   mRewardBase = 10, mRewardWeight = 1.5F;
    private double mCurrentHP, mMaxHP, mPhaseBoundary;
    private int mCurrentPhase, mStartIndex;

    void Awake()
    {
        mGemSprite = Resources.LoadAll<Sprite>("Gem");
    }

    public void GetNewGem(int id)
    {
        mStartIndex = id * mSheetCount;
        mGem.sprite = mGemSprite[mStartIndex];
        mCurrentPhase = 0;
        mCurrentHP = 0;
        mMaxHP = mRewardBase * Math.Pow(mRewardWeight, GameController.Instance.StageNumber);
        mPhaseBoundary = mMaxHP * 0.2F * (mCurrentPhase + 1);
        MainUIController.Instance.ShowProgress(mCurrentHP, mMaxHP);
    }

    public bool AddProgress(double value)
    {
        mCurrentHP += value;
        MainUIController.Instance.ShowProgress(mCurrentHP, mMaxHP);
        if (mCurrentHP >= mPhaseBoundary)
        {
            //next phase
            mCurrentPhase++;
            //GameController.Instance.NextImage();
            if (mCurrentPhase > 4)
            {
                //Clear
                //GameController.Instance.NextStage();
                GameController.Instance.Gold += mRewardBase * Math.Pow(mRewardWeight, GameController.Instance.StageNumber);
                return true;
            }
            Timer effect = mEffectPool.GetFromPool((int)eEffectType.PhaseShift);
            effect.transform.position = mGem.transform.position;

            mGem.sprite = mGemSprite[mStartIndex + mCurrentPhase];
            mPhaseBoundary = mMaxHP * 0.2f * (mCurrentPhase + 1);
        }
        return false;
    }
}
