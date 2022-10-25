using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class newGameController : MonoBehaviour
{
 
    [Header("共通")]
    [Range(1,3)] public int day_id = 1; //n日目の分か、
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

    public Image KanjiTargetImage;
    public GameObject KanjiTargetImageGameObject;
    //public GameObject KanjichoicesBox;
    //public GameObject[] KanjiChoicesParents;

    public List<Image> KanjiChoices = new List<Image>(); 
    public List<string> SyutsudaiKanji;

    //string testKanjiString = "伺,鬱,璧"; //この下位で出題される漢字のリスト化


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(kanji_Question_Data.param[0].id);
        //Debug.Log(kanji_Question_Data.param[0].kanji);
        //Debug.Log(kanji_Question_Data.param[0].example);
        makeNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        setsumonNumberUI.text = "第" + (question_number_now).ToString() + "問";
        //KanjiTargetName = kanji_Question_Data.param[0].kanji;
        LevelUI.text = "レベル" + level_id.ToString();
    }


    public void setSyutudaiKanji(){
        //ここでセクションの漢字をセットする処理
        //クリアしたら順次リストから削除していく
        //(レベルが変わったら再びセットする)
    }

    public void makeNewQuestion(){

        var targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        var mondai_n_str = question_number_now + 1;

        if (level_id == 1){
        targetKanji = kanji_Question_Data.param[question_number_now].kanji; 
        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        }
        else if (level_id == 2){
        //レベル2用の画像を読み込む
        targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        //↓ここの画像を差し替える必要あり(ステージ2用のファイル名)
        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");

        }else if(level_id == 3){
        //レベル3は画像オブジェクトを非表示にする
        targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        try{
        KanjiTargetImageGameObject.SetActive(false);}
        catch (System.NullReferenceException e){
            Debug.Log(e);
        }

        }

        
        
        KanjiReibunUI.text  = kanji_Question_Data.param[question_number_now].example;

        Debug.Log("1025版/"+mondai_n_str.ToString()+"_"+ targetKanji + "_0");
        //KanjiReibunUI.text = kanji_Question_Data.param[section_id].example;

        for (int i = 0; i <4; i++){
            var filename = targetKanji+ "_"+ i.ToString();
            //Debug.Log(filename);
            KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/"+ mondai_n_str.ToString()+"_"+targetKanji + "_" + i.ToString());
        }
        question_number_now += 1;
    }

}
