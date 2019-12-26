using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#pragma warning disable CS0649
public class JsonGenerator : MonoBehaviour
{
    [SerializeField] private ColleagueData[] mDataArr;
    [SerializeField] private PlayerInfo[] mPlayerInfos;

    void Start()
    {
        mDataArr = new ColleagueData[3];
        {
            //mDataArr[0] = new ColleagueData
            //{
            //    Name = "No.1",
            //    Level = 0,
            //    Contents = "<color=#ff0000ff>{1}초</color> 마다 <color=#0000ffff>{0}골드</color>를 획득합니다.",
            //    JobTime = 1.1f,
            //    JobType = eJobType.Gold,
            //    ValueCurrent = 1,
            //    ValueWeight = 1.08d,
            //    ValueBase = 1,
            //    CostCurrent = 100,
            //    CostWeight = 1.2d,
            //    CostBase = 100
            //};

            //mDataArr[1] = new ColleagueData
            //{
            //    Name = "No.2",
            //    Level = 0,
            //    Contents = "<color=#ff0000ff>{1}초</color> 마다 한번씩 터치를 해줍니다.",
            //    JobTime = 1f,
            //    JobType = eJobType.Touch,
            //    ValueCurrent = 0,
            //    ValueWeight = 1.08d,
            //    ValueBase = 1,
            //    CostCurrent = 200,
            //    CostWeight = 1.2d,
            //    CostBase = 200
            //};

            //mDataArr[2] = new ColleagueData
            //{
            //    Name = "No.3",
            //    Level = 0,
            //    Contents = "<color=#ff0000ff>{1}초</color> 마다 <color=#0000ffff>{0}골드</color>를 획득합니다.",
            //    JobTime = 1.5f,
            //    JobType = eJobType.Gold,
            //    ValueCurrent = 2,
            //    ValueWeight = 1.1d,
            //    ValueBase = 2,
            //    CostCurrent = 300,
            //    CostWeight = 1.2d,
            //    CostBase = 300
            //};
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GenerateColleague();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadColleague();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GeneragePlayerInfos();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadPlayerInfos();
        }
    }

    public void GenerateColleague()
    {
        string data = JsonConvert.SerializeObject(mDataArr, Formatting.Indented);
        Debug.Log(data);
        StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/JsonFiles/Colleague.json");
        writer.Write(data);
        writer.Close();
    }

    public void GeneragePlayerInfos()
    {
        mPlayerInfos = PlayerInfoController.Instance.Infos;
        string data = JsonConvert.SerializeObject(mPlayerInfos, Formatting.Indented);
        StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/JsonFiles/PlayerInfo.json");
        writer.Write(data);
        writer.Close();
    }

    private void LoadColleague()
    {
        string data = Resources.Load<TextAsset>("/Resources/JsonFiles/Colleague").text;
        Debug.Log(data);
        mDataArr = JsonConvert.DeserializeObject<ColleagueData[]>(data);
    }

    private void LoadPlayerInfos()
    {
        string data = Resources.Load<TextAsset>("/Resources/JsonFiles/PlayerInfo").text;
        mPlayerInfos = JsonConvert.DeserializeObject<PlayerInfo[]>(data);
    }

    private void LoadSample()
    {
        string data = Resources.Load<TextAsset>("JsonFiles/text").text;
        string[] dataArr = data.Split('\n');
        Debug.Log(dataArr.Length);
        Dummy[] mSampleArr = new Dummy[dataArr.Length - 2];
        for (int i = 0; i < mSampleArr.Length; i++)
        {
            string[] splited = dataArr[i + 1].Split(',');
            mSampleArr[i] = new Dummy();
            mSampleArr[i].id = int.Parse(splited[0]);
            mSampleArr[i].name = splited[1];
            mSampleArr[i].value = int.Parse(splited[2]);
        }
    }
}

[System.Serializable]
public class Dummy
{
    public int id;
    public string name;
    public int value;
}
