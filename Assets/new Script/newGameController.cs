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
    ///
    /// 
    public GameObject thirdStageButton;

    void Start()
    {
        //ebug.Log("Startが実行");
        day_id = newButtonController.selected_day_id;
        setSyutudaiKanji();
        makeNewQuestion();

        Debug.Log("day_id: " + day_id);
        Debug.Log("level_id: " + level_id);
        DayUI.text = day_id.ToString() + "日目"; //何日目か表示する分
    }

    void Update()
    {
        setsumonNumberUI.text = "第" + (question_number_now).ToString() + "問";
        //KanjiTargetName = kanji_Question_Data.param[0].kanji;
        LevelUI.text = "レベル" + level_id.ToString();
    }


    public void setSyutudaiKanji()
    {//一日分の出題する漢字をセットする
        //List<string> syutudaiKanji = new List<string>(); //要素30のstringリスト
        syutudaiKanji.AddRange(ES3.Load<string[]>("question_hairetsu"));

        syutsudaiToday = syutudaiKanji.GetRange(0, 10);

        if (day_id == 1)
        {
            syutsudaiToday = syutudaiKanji.GetRange(0, 10);
            Debug.Log("1日目");
        }
        else if (day_id == 2)
        {
            syutsudaiToday = syutudaiKanji.GetRange(10, 10);
            Debug.Log("2日目");
        }
        else if (day_id == 3)
        {
            syutsudaiToday = syutudaiKanji.GetRange(20, 10);
            Debug.Log("3日目");
        }

        for (int i = 0; i < 10; i++)
        {
            var j = int.Parse(syutsudaiToday[i]);
            var targetKanji = kanji_Question_Data.param[j].kanji;
            Debug.Log(targetKanji);
        }
    }


    public static int j;
    public void makeNewQuestion()
    {
        //Debug.Log("mekenuewquestionが呼ばれました");
        j = int.Parse(syutsudaiToday[question_number_now]); //jはユニークの漢字ID
        var targetKanji = kanji_Question_Data.param[j].kanji;
        //Debug.Log("target漢字="+targetKanji);

        var mondai_n_str = j + 1; //index調整

        if (level_id == 1)
        {
            KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_0");
            //KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+"33_薄_0");
            Debug.Log("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_0");
            //thirdStageButton.SetActive(false);
        }
        else if (level_id == 2)
        {
            //レベル2用の画像を読み込む
            KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_9");
            Debug.Log("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_9");
            //var nextbutton = GameObject.Find("レベル3");
            thirdStageButton.SetActive(false);

        }
        else if (level_id == 3)
        {
            KanjiChoiceImages.SetActive(false);
            try
            {
                KanjiTargetImageGameObject.SetActive(false);
            }
            catch (System.NullReferenceException e)
            {
                Debug.Log(e);
            }
        }

        KanjiReibunUI.text = kanji_Question_Data.param[j].example;
        
        //KanjiReibunUI.text = kanji_Question_Data.param[section_id].example;

        for (int i = 0; i < 4; i++)
        {
            var filename = targetKanji + "_" + i.ToString();
            //Debug.Log(filename);
            KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/" + mondai_n_str.ToString() + "_" + targetKanji + "_" + i.ToString());
        }

        question_number_now += 1;

    }
}



