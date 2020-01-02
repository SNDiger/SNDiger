using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

#pragma warning disable CS0649
public class GameController : MonoBehaviour
{
    #region 변수
    public static GameController Instance;
    [SerializeField] private PlayerSaveData mPlayer;

    public StaticValues.VoidCallback GoldConsumeCallback { get; set; }
    public double Gold
    {
        get { return mPlayer.Gold; }
        set
        {
            if (value >= 0)
            {
                if(mPlayer.Gold > value)
                {
                    GoldConsumeCallback?.Invoke();
                    GoldConsumeCallback = null;
                }
                mPlayer.Gold = value;
                MainUIController.Instance.ShowGold(mPlayer.Gold);
                // UI show gold
            }
            else
            {
                //돈이 부족함
                Debug.Log("Not enough gold");
            }
        }
    }
    public int StageNumber
    {
        get { return mPlayer.Stage; }
    }
    [SerializeField] private GemController mGem;

    private float mCritcalRate = PlayerInfoController.Instance.CriticalRate;
    private float mCritcalValue = PlayerInfoController.Instance.CriticalValue;

    public double TouchPower
    {
        get { return mTouchPower; }
        set { mTouchPower = value; }
    }
    private double mTouchPower;
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Load();
            mGem.LoadGem(mPlayer.GemID, mPlayer.GemHP);
        }
    }

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
        MainUIController.Instance.ShowGold(mPlayer.Gold);
        PlayerPrefs.DeleteAll();
        Load();
        StartCoroutine(LoadGames());
    }

    public void Touch()
    {
        double touchPower = mTouchPower;

        float randVal = UnityEngine.Random.value;

        if (randVal <= mCritcalRate)
        {
            touchPower *= 1 + mCritcalValue;
            Debug.Log("Critical!!!");
        }

        if(mGem.AddProgress(mTouchPower))
        {
            mPlayer.Stage++;
            mPlayer.GemID = UnityEngine.Random.Range(0, GemController.MAX_GEM_COUNT);
            mGem.GetNewGem(mPlayer.GemID);
        }
    }

    public void Save()
    {
        mPlayer.GemHP = mGem.CurrentHP;
        mPlayer.PlayerLevels = PlayerInfoController.Instance.LevelArr;
        mPlayer.ColleagueLevels = ColleagueController.Instance.LevelArr;

        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();

        formatter.Serialize(stream, mPlayer);

        string data = Convert.ToBase64String(stream.GetBuffer());
        Debug.Log(data);
        PlayerPrefs.SetString("Player", data);
        stream.Close();
    }

    public void Load()
    {
        string data = PlayerPrefs.GetString("Player");
        if (!string.IsNullOrEmpty(data))
        {
            Debug.Log(data);
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(data));

            mPlayer = (PlayerSaveData)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            mPlayer = new PlayerSaveData();
            mPlayer.GemID = -1;
            mPlayer.PlayerLevels = new int[StaticValues.PLAYER_INFOS_LEGNTH];
            mPlayer.PlayerLevels[0] = 1;
            mPlayer.ColleagueLevels = new int[StaticValues.COLLEAGUE_INFOS_LENGTH];
            mPlayer.ColleagueLevels[0] = 1;
        }
    }

    private IEnumerator LoadGames()
    {
        WaitForSeconds pointOne = new WaitForSeconds(0.1F);
        while (!PlayerInfoController.Instance.bLoaded || !ColleagueController.Instance.bLoaded)
        {
            yield return pointOne;
        }
        if (mPlayer.GemID < 0)
        {
            mGem.GetNewGem(0);
        }
        mGem.LoadGem(mPlayer.GemID, mPlayer.GemHP);
        PlayerInfoController.Instance.Load(mPlayer.PlayerLevels);
        ColleagueController.Instance.Load(mPlayer.ColleagueLevels);
    }
}
