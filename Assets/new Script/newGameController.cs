using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class newGameController : MonoBehaviour
{
    [Header("共通")]
    public static int day_id = newButtonController.selected_day_id; //n日目の分か、
    public static int level_id = 1; //stageのレベル。

    //[Range(1,3)]  public int day_id_set = 1;
    //[Range(1,3)]  public int level_id_set = 3;

    public static int question_number_now = 0;
    public kanji_question_data kanji_Question_Data;

    [Header("漢字素材")]
    public GameObject KanjiChoiceImages;
    public string imgName = "威_0.jpg";
    public string KanjiTargetName = "威";

    [Header("UIパーツ")]
    public Text setsumonNumberUI; //問題数表示
    public Text KanjiReibunUI; //例文表示
    public Text LevelUI;
    public Text DayUI;

    public Image KanjiTargetImage;
    public GameObject KanjiTargetImageGameObject;

    public List<Image> KanjiChoices = new List<Image>();
    public List<string> SyutsudaiKanji;

    //string testKanjiString = "伺,鬱,璧"; //この下位で出題される漢字のリスト化
    //↓追加
    public static List<string> syutudaiKanji = new List<string>();
    public static List<string> syutsudaiToday;
    public static int number_of_ok = 0;
    //
    //セーブデータ保存処理

    public GameObject thirdStageButton;
    public GameObject thirdDisplayKanjiButton;

    [Header("デバッグ用")]
    public bool isShuffleChoices = false;

    [Header("一時的に操作を無効にするためのパーツ") ]
    public GameObject shield;

    public static bool isSaiten_now = false;

     [Header("ｎ週目かの表示用") ]
    public static int N_shume = 1; //回答が何周目かカウントするための変数
    public GameObject N_shume_obj;

    void Start()
    {        
        day_id = newButtonController.selected_day_id;
        setSyutudaiKanji();
        makeNewQuestion();
        DayUI.text = day_id.ToString() + "日目"; //何日目か表示する分

        initialize_save_data();
    }

    void Update()
    {
        setsumonNumberUI.text = "第" + (question_number_now).ToString() + "問";
        //KanjiTargetName = kanji_Question_Data.param[0].kanji;
        LevelUI.text = "レベル" + level_id.ToString();
    }


    public static string LastKanji;

    public void setSyutudaiKanji()
    {//一日分の出題する漢字をセットする
        //List<string> syutudaiKanji = new List<string>(); //要素30のstringリスト

        syutudaiKanji.AddRange(ES3.Load<string[]>("question_hairetsu"));
        syutsudaiToday = syutudaiKanji.GetRange(0, 6);

        if (day_id == 1)
        {
            syutsudaiToday = syutudaiKanji.GetRange(0, 5);
            Debug.Log("1日目");
        }
        else if (day_id == 2)
        {
            syutsudaiToday = syutudaiKanji.GetRange(0,5);
            Debug.Log("2日目");
        }
        else if (day_id == 3)
        {
            syutsudaiToday = syutudaiKanji.GetRange(12, 6);
            Debug.Log("3日目");
        }

        LastKanji = kanji_Question_Data.param[int.Parse(syutsudaiToday[syutsudaiToday.Count - 1])].kanji;

        for (int i = 0; i < 5; i++)
        {
            var j = int.Parse(syutsudaiToday[i]);
            var targetKanji = kanji_Question_Data.param[j].kanji;
            //Debug.Log(targetKanji);
        }
    }


    public static int j;
    public static int mondai_n_str;
    public static string targetKanji;

    public void makeNewQuestion()
    {
        isSaiten_now = false;
        shield.SetActive(false);
        //Debug.Log("mekenuewquestionが呼ばれました");
        j = int.Parse(syutsudaiToday[question_number_now]); //jはユニークの漢字ID
        targetKanji = kanji_Question_Data.param[j].kanji; //もともとvar
        //Debug.Log("target漢字="+targetKanji);

        mondai_n_str = j + 1; //index調整

        if (level_id == 1)
        {
            KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_0");
            //KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+"33_薄_0");
            //Debug.Log("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_9");
            //thirdStageButton.SetActive(false);
        }
        else if (level_id == 2)
        {
            //レベル2用の画像を読み込む
            KanjiTargetImage.sprite = Resources.Load<Sprite>("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_9");
            //Debug.Log("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_9");
            //Debug.Log("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_9");
            //var nextbutton = GameObject.Find("レベル3");
            thirdStageButton.SetActive(false);
        }
        else if (level_id == 3)
        {
            KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_0");
            KanjiChoiceImages.SetActive(false); //選択肢画像を非表示
            thirdDisplayKanjiButton.SetActive(true);

            try
            {
                KanjiTargetImageGameObject.SetActive(false);//模範解答を非表示
            }
            catch (System.NullReferenceException e)
            {
                Debug.Log(e);
            }
        }

        KanjiReibunUI.text = kanji_Question_Data.param[j].example;
        
        //KanjiReibunUI.text = kanji_Question_Data.param[section_id].example;
        
        List<int> q_nums = new List<int>(){0,1,2,3};
        if (isShuffleChoices == true){
            int i = 0;
            //Debug.Log(i);
            
            while (i <= 3){
            int count_index = Random.Range(0, q_nums.Count);
            //Debug.Log(count);

            if (level_id == 1){
                KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + q_nums[count_index].ToString());
            }else{
                KanjiChoices[i].sprite = Resources.Load<Sprite>("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + q_nums[count_index].ToString());
                //Debug.Log("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + i.ToString());
            }

            q_nums.RemoveAt(count_index);
            i++;
            }


            }
        else{ //シャッフルを使用しない場合
            for (int i = 0; i < 4; i++)
        {
            var filename = targetKanji + "_" + i.ToString();
            //Debug.Log(filename);
            if (level_id == 1){
                KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + i.ToString());
            }else{
                KanjiChoices[i].sprite = Resources.Load<Sprite>("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + i.ToString());
                //Debug.Log("1101_level2/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + i.ToString());
            }
            
        }


            }

        question_number_now += 1;

    }

    
    public class KanjisSaveData{
        public KanjiSaveData[] item; 
    }

    [System.Serializable]
    public class KanjiSaveData{
        public int k_id;
        public int n_OK = 0;
        public int n_FAIL = 0;
    }


    void initialize_save_data(){
         if (ES3.KeyExists("KANJI_SCORE") == true){
            Debug.Log("セーブデータが読み込まれました");
            //jsonの読み取り処理
            string datastr =  ES3.Load<string>("KANJI_SCORE");
            SaveDataController.KANJI_SCORES = JsonUtility.FromJson<SaveDataController.KanjiSaveData[]>(datastr);
            //Debug.Log(datastr);

        KanjisSaveData kanjissavedata = JsonUtility.FromJson<KanjisSaveData>(datastr);
        var kanji_item = kanjissavedata.item;
        // for (int i = 0; i < 60; i ++){
        //     text_to_display += " id " + i.ToString();
        //     text_to_display += " " +  kanji_Question_Data.param[i].kanji;
        //     text_to_display += " 正解数 " + kanji_item[i].n_OK;
        //     text_to_display += " 失敗数 " + kanji_item[i].n_FAIL + "\n";
        // }
        // //datastr = datastr.Replace("\n","").Replace("\r", "").Replace("   "," ");
        // Debug.Log(text_to_display);
        // KanjiScoreUI.text = text_to_display;

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
    }
}}



