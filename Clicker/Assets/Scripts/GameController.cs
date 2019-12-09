using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private double mGold;
    private int mStage;
    [SerializeField] private GameController mGem;

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
    }
}
