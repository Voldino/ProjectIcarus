using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : SaveGame
{
    enum PATH
    {
        DATABASE_PATH
    }

    public class Constant
    {
        public static Dictionary<int, string> PATH_DICT = new Dictionary<int, string>()
        {
            { (int) PATH.DATABASE_PATH  ,  "/game_save/database"},
        };
    }

    public List<ScriptableObject> objects_to_save;

    public Database database;

    #region singleton 
    static public DatabaseManager instance = null;
    void Awake()
    {
        if (instance == null)
        {

            objects_to_save.Add(database);

            instance = this;
 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CallSaveData();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            CallLoadData();
        }
    }

    public override void CallLoadData()
    {
        for (int i = 0; i < objects_to_save.Count; i++)
        {
            LoadData<ScriptableObject>(objects_to_save[i], Constant.PATH_DICT[i]);
        }
    }

    public override void CallSaveData()
    {
        for (int i = 0; i < objects_to_save.Count; i++)
        {
            SaveData<ScriptableObject>(objects_to_save[i], Constant.PATH_DICT[i]);
        }
    }
}
