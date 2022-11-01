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
        if (System.IO.File.Exists(Application.dataPath + "/Json/text.json") == true){
            Debug.Log("セーブデータが読み込まれました");
            //jsonの読み取り処理
            StreamReader reader = new StreamReader(Application.dataPath + "/Json/text.json");
            string datastr = reader.ReadToEnd();

            reader.Close();
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
    }

    }
    }
