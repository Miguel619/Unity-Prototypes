using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; } // add private setter
    public Color TeamColor;
    [System.Serializable]
    class SavaData{
        public Color TeamColor;
        
    }

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    
    public void SaveColor(){
        SavaData data = new SavaData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedgame.json", json);
    }
    
    public void LoadColor(){
        string path = Application.persistentDataPath + "/savedgame.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SavaData data = JsonUtility.FromJson<SavaData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
