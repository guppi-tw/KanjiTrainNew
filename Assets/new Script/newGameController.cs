using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class newGameController : MonoBehaviour
{
 
    [Header("共通")]
    [Range(1,3)] public static int day_id = newButtonController.selected_day_id; //n日目の分か、
    [Range(1,3)] public int level_id = 1; //stageのレベル。
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
    //public GameObject KanjichoicesBox;
    //public GameObject[] KanjiChoicesParents;

    public List<Image> KanjiChoices = new List<Image>(); 
    public List<string> SyutsudaiKanji;

    //string testKanjiString = "伺,鬱,璧"; //この下位で出題される漢字のリスト化


    //↓追加
    public static List<string> syutudaiKanji = new List<string>();
    public List<string> syutsudaiToday;
    //??

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(kanji_Question_Data.param[0].id);
        //Debug.Log(kanji_Question_Data.param[0].kanji);
        //Debug.Log(kanji_Question_Data.param[0].example);
        setSyutudaiKanji();

        makeNewQuestion();
        DayUI.text = day_id.ToString()+"日目"; //何日目か表示する分

    }

    // Update is called once per frame
    void Update()
    {
        setsumonNumberUI.text = "第" + (question_number_now).ToString() + "問";
        //KanjiTargetName = kanji_Question_Data.param[0].kanji;
        LevelUI.text = "レベル" + level_id.ToString();
    }


    public void setSyutudaiKanji(){
        //List<string> syutudaiKanji = new List<string>(); //要素30のstringリスト
        syutudaiKanji.AddRange(ES3.Load<string[]>("question_hairetsu"));
        //Debug.Log(syutudaiKanji[1]);
        Debug.Log(syutudaiKanji.Count);
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
            Debug.Log(targetKanji);
        }
        

        //ここでセクションの漢字をセットする処理
        //クリアしたら順次リストから削除していく
        //(レベルが変わったら再びセットする)
    }

    public void makeNewQuestion(){
        //var targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        var j = int.Parse(syutsudaiToday[question_number_now]); //jとかわかりにくいけど一旦大目に見て...ユニークの漢字ID
        var targetKanji = kanji_Question_Data.param[j].kanji;
        Debug.Log("target漢字="+targetKanji);

        //var targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        var mondai_n_str = j + 1;

        if (level_id == 1){
        //targetKanji = kanji_Question_Data.param[question_number_now].kanji; 
        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        Debug.Log("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        }
        else if (level_id == 2){
        //レベル2用の画像を読み込む
        //targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        //↓ここの画像を差し替える必要あり(ステージ2用のファイル名)
        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_9");

        }else if(level_id == 3){
        //レベル3は画像オブジェクトを非表示にする
        //targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        try{
        KanjiTargetImageGameObject.SetActive(false);}
        catch (System.NullReferenceException e){
            Debug.Log(e);
        }

        }


        KanjiReibunUI.text  = kanji_Question_Data.param[j].example;

        //Debug.Log("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        //KanjiReibunUI.text = kanji_Question_Data.param[section_id].example;

        for (int i = 0; i <4; i++){
            var filename = targetKanji+ "_"+ i.ToString();
            //Debug.Log(filename);
            KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/"+ mondai_n_str.ToString()+"_"+targetKanji + "_" + i.ToString());
        }
        question_number_now += 1;
    }

}
