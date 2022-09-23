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
    public int tankIndex;
    public bool firstTime;

    public PlayerData (Player player)
    {
        sound = player.sound;
        music = player.music;
        master = player.master;
        tankIndex = player.tankIndex;
        firstTime = player.firstTime;
    }
}