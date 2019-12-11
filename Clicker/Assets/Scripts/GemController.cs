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
    private double mCurrentHP, mMaxHP, mPhaseBoundary;
    private int mCurrentPhase, mStartIndex;
    private MainUIController mUIController;

    void Awake()
    {
        mGemSprite = Resources.LoadAll<Sprite>("Gem");
        mUIController = GameObject.FindGameObjectWithTag("MainUIController").GetComponent<MainUIController>();
    }

    public void GetNewGem(int id)
    {
        mStartIndex = id * mSheetCount;
        mGem.sprite = mGemSprite[id * mSheetCount];
        mCurrentPhase = 0;
        mCurrentHP = 0;
        mMaxHP = 100;
        mPhaseBoundary = mMaxHP * 0.2F * (mCurrentPhase + 1);
    }

    public bool AddProgress(double value)
    {
        mCurrentHP += value;
        Debug.LogFormat("{0}/{1}", mCurrentHP, mMaxHP);
        mUIController.ShowHPBar(mCurrentHP, mMaxHP);

        if (mCurrentHP >= mMaxHP * 0.25F * mCurrentPhase)
        {
            mCurrentPhase++;
            if (mCurrentPhase > 4)
            { 
                return true;
            }
            mGem.sprite = mGemSprite[mStartIndex + mCurrentPhase];
            mPhaseBoundary = mMaxHP * 0.25F * (mCurrentPhase + 1);
        }
        return false;
    }
}