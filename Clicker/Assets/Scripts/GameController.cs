using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class GameController : MonoBehaviour
{
    #region 변수
    public static GameController Instance;

    public AnimHash.VoidCollback GoldConsumeCallback { get; set; }

    private double mGold;
    public double Gold { get { return mGold; }
        set
        {
            if (value >= 0)
            {
                if (mGold > value)
                {
                    GoldConsumeCallback?.Invoke();
                    GoldConsumeCallback = null;
                }
                mGold = value;
                MainUIController.Instance.ShowGold(mGold);
            }
            else
            {
               // 돈부족
            }
        }
    }
    private int mStage;
    public int StageNumber { get { return mStage; } }
    [SerializeField] private GemController mGem;
    #endregion

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
        MainUIController.Instance.ShowGold(mGold);
        int id = Random.Range(0, GemController.MAX_GEM_COUNT);
        mGem.GetNewGem(id);
    }

    public void Touch()
    {
        if(mGem.AddProgress(1))
        {
            mStage++;
            int id = Random.Range(0, GemController.MAX_GEM_COUNT);
            mGem.GetNewGem(id);
        }
    }
}
