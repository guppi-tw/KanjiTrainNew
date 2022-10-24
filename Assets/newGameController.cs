using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class newGameController : MonoBehaviour
{

    public static int day_id = 1;
    public static int question_number_now = 1;
    public kanji_question_data kanji_Question_Data;

    public GameObject KanjiChoiceImages;
    public string imgName = "威_0.jpg";
    public string KanjiTargetName = "威";

    public Text setsumonNumberUI; //問題数表示
    public Text KanjiReibunUI; //例文表示


    public Image KanjiTargetImage;
    //public GameObject KanjichoicesBox;
    //public GameObject[] KanjiChoicesParents;

    public List<Image> KanjiChoices = new List<Image>(); 

    public List<string> SyutsudaiKanji;
    string testKanjiString = "伺,鬱,璧"; //この下位で出題される漢字のリスト化


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
        KanjiTargetName = kanji_Question_Data.param[0].kanji;

    }

    public void makeNewQuestion(){
        var targetKanji = kanji_Question_Data.param[question_number_now].kanji;
        Debug.Log(targetKanji);

        KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/"+question_number_now.ToString()+"_"+ targetKanji + "_0");
        Debug.Log("1025版/"+question_number_now.ToString()+"_"+ targetKanji + "_0");
        //KanjiReibunUI.text = kanji_Question_Data.param[section_id].example;

        for (int i = 0; i <4; i++){
            var filename = targetKanji+ "_"+ i.ToString();
            //Debug.Log(filename);
            KanjiChoices[i].sprite = Resources.Load<Sprite>("1025版/"+ question_number_now.ToString()+"_"+targetKanji + "_" + i.ToString());
        }
        question_number_now += 1;
    }

}
