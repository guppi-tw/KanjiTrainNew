using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameController : MonoBehaviour
{

    public static string QuestionKanji = "漢";
    public string ChosenKanji = "漢";
    public TextMeshProUGUI QuestionKanjiUGUI;

    public Kanji_Data Kanji_Data;

    public List<Kanji_Data.Param> param = new List<Kanji_Data.Param>();
    public List<Kanji_Data.Param> SectionKanjis = new List<Kanji_Data.Param>();

    //1~200, 201~400, 401~585, 586~766 でそれぞれ3,4,5,6年の漢字が相当。

    [SerializeField, Range(0, 39)]
    public int section_id; //セクションの番号

    List<int> question_numbers; //該当する漢字のIDリスト

    int kanji_start_id = 1;
    int kanji_end_id;
    public static int kanji_question_now = 0;

    //基本的にセクションは20ごとに区切られる。
    public GameObject ANSWER_ZONE; //回答用の処理を司る部分。レベルに応じて色々変える予定。
    List<GameObject> AnswerCards12; //回答カードのリスト。1と2で用いる。

    


    void Start()
    {
        

        section_id = StageButtonController.CHOSEN_STAGE_ID; //選んだセクションIDを代入
        kanji_start_id = (section_id) * 20;
        kanji_end_id = (kanji_start_id) + 20;

        kanji_question_now = 0;

        param = Kanji_Data.param; //全漢字のデータを取得
        SectionKanjis = param.GetRange(kanji_start_id, kanji_end_id); //セクションの出題範囲の漢字に絞り込む

        //AnswerCards12 = ANSWER_ZONE.GetComponentsInChildren<GameObject>();

        Debug.Log(SectionKanjis[kanji_question_now].choices.Split(','));
        Debug.Log(SectionKanjis[kanji_question_now].choices.GetType());

        setChoices();

    
    }


    void Update()
    {
        QuestionKanji = SectionKanjis[kanji_question_now].kanji;
        QuestionKanjiUGUI.text = SectionKanjis[kanji_question_now].kanji;

    }



    public void testNextQuestion()
    {
        //次の問題を出題、あるいはクリア処理
        if (kanji_question_now < 19)
        {
            kanji_question_now += 1;
            setChoices();
        }
        else
        {
            kanji_question_now = 0;
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void NextQuestion()
    {
        //次の問題を出題、あるいはクリア処理   
        if (kanji_question_now == 0)
        {
            setChoices();
        }
        else if (kanji_question_now < 20)
        {
            kanji_question_now += 1;
            setChoices();
        }
        else
        {
            SceneManager.LoadScene("ClearScene");
        }
        //Debug.Log(kanji_question_now);
    }

    void setChoices(){ //選択肢を用意するための処理
        var int_choice = 0;
        var ans_choice = Random.Range(0,4); //0 ~ 4の間でランダムな整数値を返す
        foreach (Transform childTransform in ANSWER_ZONE.transform)
        {
            //Debug.Log(childTransform);
            var ans = childTransform.GetComponentInChildren<TextMeshProUGUI>();
            //var kanji_choices = SectionKanjis[kanji_question_now].choices.Split(",");
            if (int_choice == ans_choice){
                ans.text = SectionKanjis[kanji_question_now].kanji;
            }else{
                var choices = SectionKanjis[kanji_question_now].choices.Split(',');
                ans.text = choices[int_choice]; //string型から選択肢部分のみを抽出、代入
            }

            //Debug.Log(ans.text);
            int_choice += 1;
        }
    }




    public void toMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

}

