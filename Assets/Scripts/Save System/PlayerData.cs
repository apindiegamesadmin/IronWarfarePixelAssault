using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float sound;
    public float music;
    public float master;
    public int screenIndex;
    public int tankIndex;
    public bool firstTime;
    public int missionIndex;

    public PlayerData (Player player)
    {
        sound = player.sound;
        music = player.music;
        master = player.master;
        screenIndex = player.screenIndex;
        tankIndex = player.tankIndex;
        firstTime = player.firstTime;
        missionIndex = player.missionIndex;
    }
}
