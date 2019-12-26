using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public AnimHash.VoidCallback GoldConsumeCallback { get; set; }
    [SerializeField] private double mGold;
    public double Gold {
        get { return mGold; }
        set
        {
            if (value >= 0)
            {
                if(mGold > value)
                {
                    GoldConsumeCallback?.Invoke();
                    GoldConsumeCallback = null;
                }
                mGold = value;
                MainUIController.Instance.ShowGold(mGold);
                // UI show gold
            }
            else
            {
                //돈이 부족함
                Debug.Log("Not enough gold");
            }
        }
    }
    private int mStage;
    public int StageNumber
    {
        get { return mStage; }
    }
    [SerializeField] private GemController mGem;

    public double TouchPower
    {
        get { return mTouchPower; }
        set { mTouchPower = value; }
    }
    private double mTouchPower;

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

    void Start()
    {
        MainUIController.Instance.ShowGold(0);
        int id = Random.Range(0, GemController.MAX_GEM_COUNT);
        mGem.GetNewGem(id);
    }

    public void Touch()
    {
        if(mGem.AddProgress(mTouchPower))
        {
            mStage++;
            int id = Random.Range(0, GemController.MAX_GEM_COUNT);
            mGem.GetNewGem(id);
        }
    }
}
