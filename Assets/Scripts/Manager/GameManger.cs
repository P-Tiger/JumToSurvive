using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManger : MonoBehaviour
{
    // Start is called before the first frame update
    private const string Hight_Score = "Hight Score";
    public static GameManger instance;

    private void Awake()
    {
        makeIntance();
    }
    void makeIntance()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void IsGameStartedForTheFirst() // if you download the first high score = 0
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirst"))
        {
            PlayerPrefs.SetInt(Hight_Score, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirst", 0);
        }
    }
    
    public void SetHightScore(int score)
    {
        PlayerPrefs.SetInt(Hight_Score, score);
    }

    public int GetHightScore()
    {
        return PlayerPrefs.GetInt(Hight_Score);
    }

}
