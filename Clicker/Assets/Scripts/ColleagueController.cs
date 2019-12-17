using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class ColleagueController : MonoBehaviour
{
    public static ColleagueController Instance;
    private ColleagueData[] mDataArr;
    [SerializeField] private Colleague[] mPrefabArr;
    private List<Colleague> mSpawnedList;
    [SerializeField] private Transform mSpawnPos;

    [SerializeField] private Sprite[] mIconArr;

    [SerializeField] private UIElement mElementPrefab;
    [SerializeField] private Transform mScrollTarget;
    private List<UIElement> mElementList; 

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
            Contents = "{1}초마다 {0}골드를 획득합니다",
            JobTime = 1.1F,
            JobType = eJobType.Gold,
            ValueCurrent = 50D,
            CostCurrent = 100D
        };

        mDataArr[1] = new ColleagueData
        {
            Name = "No.2",
            Level = 0,
            Contents = "{0}초마다 한번씩 터치를 해줍니다",
            JobTime = 1F,
            JobType = eJobType.Touch,
            ValueCurrent = 0D,
            CostCurrent = 200D
        };

        mDataArr[2] = new ColleagueData
        {
            Name = "No.3",
            Level = 0,
            Contents = "{1}초마다 {0}골드를 획득합니다",
            JobTime = 1.5F,
            JobType = eJobType.Gold,
            ValueCurrent = 300D,
            CostCurrent = 300D
        };
    }

    void Start()
    {
        mElementList = new List<UIElement>();
        for (int i = 0; i < mDataArr.Length; i++)
        {
            UIElement elem = Instantiate(mElementPrefab, mScrollTarget);
            elem.Init(null, i, mDataArr[i].Name, mDataArr[i].Contents, "구매", mDataArr[i].Level,
                      mDataArr[i].ValueCurrent, mDataArr[i].CostCurrent, mDataArr[i].JobTime, AddLevel);
            mElementList.Add(elem);
        }
    }

    public void JobFinish(int id)
    {
        ColleagueData data = mDataArr[id];
        switch(data.JobType)
        {
            case eJobType.Gold:
                GameController.Instance.Gold += data.ValueCurrent;
                break;
            case eJobType.Touch:
                GameController.Instance.Touch();
                break;
            default:
                Debug.LogError("Wrong job type " + data.JobType);
                break;
        }
    }

    public void AddLevel(int id, int amount)
    {
        if (mDataArr[id].Level == 0)
        {
            Colleague newCol = Instantiate(mPrefabArr[id]);
            newCol.transform.position = mSpawnPos.position;
            newCol.Init(id, mDataArr[id].JobTime);
            mSpawnedList.Add(newCol);
        }
        mDataArr[id].Level += amount;
        mDataArr[id].ValueCurrent += mDataArr[id].Level;
        mDataArr[id].CostCurrent += mDataArr[id].Level;
        mElementList[id].Renew(mDataArr[id].Contents, "구매", mDataArr[id].Level, mDataArr[id].ValueCurrent, mDataArr[id].CostCurrent, mDataArr[id].JobTime);
    }
}
public class ColleagueData
{
    public string Name;
    public int Level;
    public string Contents;
    public float JobTime;
    public eJobType JobType;
    public double ValueCurrent;
    public double CostCurrent;
}
public enum eJobType
{
    Gold,
    Touch
}