using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "Resources/Saves/";
    private static readonly string ANDROID_SAVE_FOLDER = Application.persistentDataPath + "Resources/Saves/";
    public static void Init()
    {
#if UNITY_EDITOR
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
#elif UNITY_ANDROID
        if (!Directory.Exists(ANDROID_SAVE_FOLDER))
        {
            Directory.CreateDirectory(ANDROID_SAVE_FOLDER);
        }
#endif
    }
    public static void SavePlayerData(Player player)
    {
        Init();
        BinaryFormatter formatter = new BinaryFormatter();
#if UNITY_EDITOR
        string path = SAVE_FOLDER + "/player.dat";
#elif UNITY_ANDROID
        string path = ANDROID_SAVE_FOLDER + "/player.dat";
#endif
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayerData()
    {
#if UNITY_EDITOR
        string path = SAVE_FOLDER + "/player.dat";
#elif UNITY_ANDROID
        string path = ANDROID_SAVE_FOLDER + "/player.dat";
#endif

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
