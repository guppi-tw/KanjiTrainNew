using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataController : MonoBehaviour
{

public static KanjiSaveData[] KANJI_SCORES;

    public class KanjisSaveData{
        public KanjiSaveData[] item; 
    }

    [System.Serializable]
    public class KanjiSaveData{
        public int k_id;
        public int n_OK = 0;
        public int n_FAIL = 0;
    }

    // Start is called before the first frame update
    void Awake()
    {
        //  if (ES3.KeyExists("kanjiScore") == true){
        //     //Debug.Log("セーブデータが読み込まれました");
        //     //jsonの読み取り処理

        //     //StreamReader reader = new StreamReader(Application.dataPath + @"/Resources/Json/text.json");
        //     //string datastr = reader.ReadToEnd();
        //     //reader.Close();
        //     string datastr =  ES3.Load<string>("KANJI_SCORE");
        //     KANJI_SCORES = JsonUtility.FromJson<KanjiSaveData[]>(datastr);
        //     //Debug.Log(datastr);

        // }else{
        //     Debug.Log("セーブデータが初期化されました");
        //     KanjisSaveData save = new KanjisSaveData();
        //     save.item = new KanjiSaveData[60];
        //     for (int i = 0; i <= 59; i++){
        //         save.item[i] = new KanjiSaveData();
        //         save.item[i].k_id = i; 
        //     }

        // //string filePath = Application.dataPath + @"Resources/Json/text.json";
        // //string filePath = "/Json/text.json";
        // string json = JsonUtility.ToJson(save, true);
        // ES3.Save<string>("KANJI_SCORE", json);

        // // StreamWriter streamWriter = new StreamWriter(filePath);
        // // streamWriter.Write(json);
        // // streamWriter.Flush();
        // // streamWriter.Close();
        // Debug.Log("save処理が実行");
        // }

        // if (System.IO.File.Exists(Application.dataPath + @"/Resources/Json/text.json") == true){
        //     Debug.Log("セーブデータが読み込まれました");
        //     //jsonの読み取り処理

        //     StreamReader reader = new StreamReader(Application.dataPath + @"/Resources/Json/text.json");
        //     string datastr = reader.ReadToEnd();
        //     reader.Close();
        //     KANJI_SCORES = JsonUtility.FromJson<KanjiSaveData[]>(datastr);
        //     //Debug.Log(datastr);
        // }else{
        //     Debug.Log("セーブデータが初期化されました");
        //     KanjisSaveData save = new KanjisSaveData();
        //     save.item = new KanjiSaveData[60];
        //     for (int i = 0; i <= 59; i++){
        //         save.item[i] = new KanjiSaveData();
        //         save.item[i].k_id = i; 
        //     }
            




    }

}
