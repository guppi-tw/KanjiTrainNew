using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class newGameController : MonoBehaviour
{
 
    [Header("共通")]
    [Range(1,3)] public static int day_id = newButtonController.selected_day_id; //n日目の分か、
    [Range(1,3)] public static int level_id = 1; //stageのレベル。
    
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
    //??
    //セーブデータ保存処理
    ///
    /// 



    void Start()
    {
        //ebug.Log("Startが実行");
        day_id = newButtonController.selected_day_id;
        
        setSyutudaiKanji();
        makeNewQuestion();
        
        Debug.Log("day_id: " + day_id);
        Debug.Log("level_id: " + level_id);

        DayUI.text = day_id.ToString()+"日目"; //何日目か表示する分

    }

    void Update()
    {
        setsumonNumberUI.text = "第" + (question_number_now).ToString() + "問";
        //KanjiTargetName = kanji_Question_Data.param[0].kanji;
        LevelUI.text = "レベル" + level_id.ToString();
    }


    public void setSyutudaiKanji(){//一日分の出題する漢字をセットする
        //List<string> syutudaiKanji = new List<string>(); //要素30のstringリスト
        syutudaiKanji.AddRange(ES3.Load<string[]>("question_hairetsu"));
        //Debug.Log(syutudaiKanji[1]);
        //Debug.Log(syutudaiKanji.Count);

        syutsudaiToday = syutudaiKanji.GetRange(0,10);
        if (day_id == 1){
            syutsudaiToday = syutudaiKanji.GetRange(0,10);
            Debug.Log("1日目");
        }else if (day_id == 2){
            syutsudaiToday = syutudaiKanji.GetRange(10,10);
            Debug.Log("2日目");
        }else if (day_id == 3){
            syutsudaiToday = syutudaiKanji.GetRange(20,10);
            Debug.Log("3日目");
        }

        for (int i = 0; i < 10 ; i++){
            var j = int.Parse(syutsudaiToday[i]);
            var targetKanji = kanji_Question_Data.param[j].kanji;
            //Debug.Log(targetKanji);
        }
    }

    public void makeNewQuestion(){

        //Debug.Log("mekenuewquestionが呼ばれました");
        var j = int.Parse(syutsudaiToday[question_number_now]); //jはユニークの漢字ID
        var targetKanji = kanji_Question_Data.param[j].kanji;
        Debug.Log("target漢字="+targetKanji);
        var mondai_n_str = j + 1; //index調整

        if (level_id == 1){
        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        //Debug.Log("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        }
        else if (level_id == 2){
        //レベル2用の画像を読み込む
        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_9");
        Debug.Log("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_9");

        }else if(level_id == 3){
        //レベル3は画像オブジェクトを非表示にする
        try{
        KanjiTargetImageGameObject.SetActive(false);}
        catch (System.NullReferenceException e){
            Debug.Log(e);
        } }

        KanjiReibunUI.text  = kanji_Question_Data.param[j].example;
        //KanjiReibunUI.text = kanji_Question_Data.param[section_id].example;
        for (int i = 0; i <4; i++){
            var filename = targetKanji+ "_"+ i.ToString();
            //Debug.Log(filename);
            KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/"+ mondai_n_str.ToString()+"_"+targetKanji + "_" + i.ToString());
        }
        question_number_now += 1;
    }
}



