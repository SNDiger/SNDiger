using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#pragma warning disable CS0649
public class TitleController : MonoBehaviour
{
    [SerializeField] private Button mStartButton;
    [SerializeField] private Text mStatusText;
    ObjPool<Transform> mTransform;

    void Start()
    {
        mStartButton.onClick.AddListener(StartMainGame);
        mStatusText.text = "Touch to Start";
    }

    public void StartMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
