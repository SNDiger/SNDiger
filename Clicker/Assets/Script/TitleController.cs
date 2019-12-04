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

    void Start()
    {
        mStartButton.onClick.AddListener(StartMainGame);
        mStatusText.text = "터치해 시작";
    }

    public void StartMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
