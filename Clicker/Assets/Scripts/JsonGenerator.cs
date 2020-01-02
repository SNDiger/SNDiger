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
    [SerializeField] private Dummy[] mSampleArr;

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
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadPlayer();
        }
    }

    public void GenerateColleague()
    {
        string data = JsonConvert.SerializeObject(mDataArr, Formatting.Indented);
        Debug.Log(data);
        StreamWriter writer = new StreamWriter(Application.dataPath + "/Colleague.json");
        writer.Write(data);
        writer.Close();
    }

    private void LoadColleague()
    {
        string data = Resources.Load<TextAsset>("JsonFiles/Colleague").text;
        Debug.Log(data);
        mDataArr = JsonConvert.DeserializeObject<ColleagueData[]>(data);
    }

    private void SavePlayer()
    {
        mPlayerInfos = PlayerInfoController.Instance.Infos;
        string data = JsonConvert.SerializeObject(mPlayerInfos, Formatting.Indented);
        Debug.Log(data);
        StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/JsonFiles/PlayerInfo.json");
        writer.Write(data);
        writer.Close();
    }

    private void LoadPlayer()
    {
        string data = Resources.Load<TextAsset>("JsonFiles/PlayerInfo").text;
        Debug.Log(data);
        mPlayerInfos = JsonConvert.DeserializeObject<PlayerInfo[]>(data);
    }

    private void LoadSample()
    {
        string data = Resources.Load<TextAsset>("JsonFiles/test").text;
        string[] dataArr = data.Split('\n');
        Debug.Log(dataArr.Length);
        mSampleArr = new Dummy[dataArr.Length - 2];
        for(int i =0; i < mSampleArr.Length; i++)
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