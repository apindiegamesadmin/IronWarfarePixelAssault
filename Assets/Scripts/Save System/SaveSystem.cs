using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "Resources/Saves/";
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {

            Directory.CreateDirectory(SAVE_FOLDER);
            Debug.Log(SAVE_FOLDER);
        }
    }
    public static void SavePlayerData(Player player)
    {
        Init();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = SAVE_FOLDER + "/player.dat";
        Debug.Log("Saved Data");
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayerData()
    {
        string path = SAVE_FOLDER + "/player.dat";

        if (File.Exists(path))
        {
            Debug.Log("Loaded Data");
            Debug.Log(path);
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
