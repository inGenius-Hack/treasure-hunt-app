using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Ingenius.UI;

public static class SaveSytem
{
   public static void SavePlayer(UI_System player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.ss";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.ss";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data=formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
            
        }
        else
        {
            Debug.LogError("Save file not found "+path);
            return null;
        }
    }
}
