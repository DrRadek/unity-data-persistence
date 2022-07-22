using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data : MonoBehaviour
{
    public int bestScore = 0;
    public string bestScoreName = "";
    public string currentName = "";

    static string path;

    public static Data instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/savefile.json";
            LoadData();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public static void SaveData()
    {
        
        File.WriteAllText(path, JsonUtility.ToJson(instance));
    }

    public static void LoadData()
    {
        if (File.Exists(path))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(path), instance);
        }
            
    }
}
