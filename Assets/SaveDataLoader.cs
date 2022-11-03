using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveDataLoader : MonoBehaviour
{

    public Text KanjiScoreUI;
    string text_to_display;
    public kanji_question_data kanji_Question_Data;

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
    void Start()
    {
        if (ES3.KeyExists("KANJI_SCORE") == true){
            Debug.Log("セーブデータが読み込まれました");
            //jsonの読み取り処理
            string datastr =  ES3.Load<string>("KANJI_SCORE");
            SaveDataController.KANJI_SCORES = JsonUtility.FromJson<SaveDataController.KanjiSaveData[]>(datastr);
            //Debug.Log(datastr);

        KanjisSaveData kanjissavedata = JsonUtility.FromJson<KanjisSaveData>(datastr);
        var kanji_item = kanjissavedata.item;
        for (int i = 0; i < 60; i ++){
            text_to_display += " id " + i.ToString();
            text_to_display += " " +  kanji_Question_Data.param[i].kanji;
            text_to_display += " 正解数 " + kanji_item[i].n_OK;
            text_to_display += " 失敗数 " + kanji_item[i].n_FAIL + "\n";
        }

        //datastr = datastr.Replace("\n","").Replace("\r", "").Replace("   "," ");
        Debug.Log(text_to_display);
        KanjiScoreUI.text = text_to_display;

    }else{
        Debug.Log("セーブデータが初期化されました");
            KanjisSaveData save = new KanjisSaveData();
            save.item = new KanjiSaveData[60];
            for (int i = 0; i <= 59; i++){
                save.item[i] = new KanjiSaveData();
                save.item[i].k_id = i; 
            }

        string json = JsonUtility.ToJson(save, true);
        ES3.Save<string>("KANJI_SCORE", json);
        Debug.Log("save処理が実行");

        var kanji_item = save.item;
        for (int i = 0; i < 60; i ++){
            text_to_display += " id " + i.ToString();
            text_to_display += " " +  kanji_Question_Data.param[i].kanji;
            text_to_display += " 正解数 " + kanji_item[i].n_OK;
            text_to_display += " 失敗数 " + kanji_item[i].n_FAIL + "\n";
        }

        //datastr = datastr.Replace("\n","").Replace("\r", "").Replace("   "," ");
        Debug.Log(text_to_display);
        KanjiScoreUI.text = text_to_display;

    }

    }

    public void ResetSaveData(){
        KanjisSaveData save = new KanjisSaveData();
        save.item = new KanjiSaveData[60];
            for (int i = 0; i <= 59; i++){
                save.item[i] = new KanjiSaveData();
                save.item[i].k_id = i; 
                save.item[i].n_OK = 0; 
                save.item[i].n_FAIL = 0; 
            }

        string json = JsonUtility.ToJson(save, true);
        ES3.Save<string>("KANJI_SCORE", json);
        //Debug.Log("save処理が実行");

        var kanji_item = save.item;
        for (int i = 0; i < 60; i ++){
            text_to_display += " id " + i.ToString();
            text_to_display += " " +  kanji_Question_Data.param[i].kanji;
            text_to_display += " 正解数 " + kanji_item[i].n_OK;
            text_to_display += " 失敗数 " + kanji_item[i].n_FAIL + "\n";
        }

        //datastr = datastr.Replace("\n","").Replace("\r", "").Replace("   "," ");
        Debug.Log(text_to_display);
        KanjiScoreUI.text = text_to_display;

    }

    }
