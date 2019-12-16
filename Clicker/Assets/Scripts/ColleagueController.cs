using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class ColleagueController : MonoBehaviour
{
    public static ColleagueController Instance;
    private ColleagueData[] mDataArr;
    [SerializeField] private Colleague[] mPrefabArr;
    [SerializeField] private Transform mSpawnPos;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        mDataArr = new ColleagueData[3];
        mDataArr[0] = new ColleagueData
        {
            Name = "No.1",
            Level = 0,
            Contents = "{0}초마다 {1}골드를 획득합니다",
            JobTime = 1.1f,
            JobType = eJobType.Gold,
            CostCurrent = 100
        };

        mDataArr[1] = new ColleagueData
        {
            Name = "No.2",
            Level = 0,
            Contents = "{0}초마다 한번씩 터치를 해줍니다",
            JobTime = 1f,
            JobType = eJobType.Touch,
            CostCurrent = 200
        };

        mDataArr[2] = new ColleagueData
        {
            Name = "No.3",
            Level = 0,
            Contents = "{0}초마다 {1}골드를 획득합니다",
            JobTime = 1.5F,
            JobType = eJobType.Gold,
            CostCurrent = 300
        };
    }

    public void JobFinish(int id)
    {
        ColleagueData data = mDataArr[id];
        switch(data.JobType)
        {
            case eJobType.Gold:
                GameController.Instance.Gold += 1;
                break;
            case eJobType.Touch:
                GameController.Instance.Touch();
                break;
            default:
                Debug.LogError("Wrong job type " + data.JobType);
                break;
        }
    }

    public void TempInstantiate(int id)
    {
        AddLevel(id, 1);
    }

    public void AddLevel(int id, int amount)
    {
        Colleague newCol = Instantiate(mPrefabArr[id]);
        newCol.transform.position = mSpawnPos.position;
        newCol.Init(mDataArr[id].Name, id, mDataArr[id].JobTime);
    }
}
public class ColleagueData
{
    public string Name;
    public int Level;
    public string Contents;
    public float JobTime;
    public eJobType JobType;
    public double CostCurrent;
}
public enum eJobType
{
    Gold,
    Touch
}