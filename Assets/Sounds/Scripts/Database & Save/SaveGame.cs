using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class SaveGame : MonoBehaviour
{
    public abstract void CallLoadData();
    public abstract void CallSaveData();


    public void LoadData<T>(T data, string path) where T : ScriptableObject
    {
        BinaryFormatter bf = new BinaryFormatter();

        // to check if path(s) exit 
        if (!Directory.Exists(Application.persistentDataPath + "/game_save")) Directory.CreateDirectory(Application.persistentDataPath + "/game_save");

        /*Actual data loading*/
        if (File.Exists(Application.persistentDataPath + path))
        {
            FileStream dataStream = File.Open(Application.persistentDataPath + path, FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(dataStream), data);
            dataStream.Close();
        }
    }

    public void SaveData<T>(T data, string path) where T : ScriptableObject
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        BinaryFormatter converter = new BinaryFormatter();
        FileStream dataStream = File.Create(Application.persistentDataPath + path);

        var json = JsonUtility.ToJson(data);
        converter.Serialize(dataStream, json);
        dataStream.Close();
    }
}
