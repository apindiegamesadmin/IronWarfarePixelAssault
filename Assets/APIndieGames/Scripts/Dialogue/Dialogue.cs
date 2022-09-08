using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public Conversation[] conversation;
}

[System.Serializable]
public class Conversation
{
    public enum character { TankCommander, Narrator, Villain };

    public character Character;

    [TextArea(3, 10)]
    public string[] sentences;
}
