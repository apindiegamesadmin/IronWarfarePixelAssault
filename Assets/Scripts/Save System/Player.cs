using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;
using System;

public class Player : MonoBehaviour
{
    public float sound;
    public float music;
    public float master;
    public int screenIndex;
    public int tankIndex;
    public bool firstTime;
    public int missionIndex;

    public PlayerData playerData;
    private static Player instance = null;
    public static Player Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        LoadPlayerData();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayerData(this);
    }

    public void LoadPlayerData()
    {
        playerData = SaveSystem.loadPlayerData();
        if (playerData != null)
        {
            sound = playerData.sound;
            music = playerData.music;
            master = playerData.master;
            screenIndex = playerData.screenIndex;
            tankIndex = playerData.tankIndex;
            firstTime = playerData.firstTime;
            missionIndex = playerData.missionIndex;
        }
        else
        {
            sound = 0.5f;
            music = 0.5f;
            master = 0.5f;
            screenIndex = 0;
            tankIndex = 1;
            firstTime = true;
            missionIndex = 0;
            SavePlayerData();
        }
    }
}
