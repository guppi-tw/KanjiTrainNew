using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public string QuestionKanji = "漢";
    public string ChosenKanji = "漢";
    public TextMeshProUGUI QuestionKanjiUGUI;

    public Kanji_Data Kanji_Data;

    public List<Kanji_Data.Param> param = new List<Kanji_Data.Param> ();
    public List<Kanji_Data.Param> SectionKanjis = new List<Kanji_Data.Param> ();
    
    //1~200, 201~400, 401~585, 586~766 でそれぞれ3,4,5,6年の漢字が相当。

    [SerializeField, Range(0,39)]
    public int section_id; //セクションの番号

    List<int> question_numbers; //該当する漢字のIDリスト

    int kanji_start_id = 1;
    int kanji_end_id;

    int kanji_question_now = 0;
    //基本的にセクションは20ごとに区切られる。



    void Start()
    {

        kanji_start_id = (section_id) * 20;
        kanji_end_id = (kanji_start_id) + 20;
        kanji_question_now = 0;

        param = Kanji_Data.param; //全漢字のデータを入れる

        // for (int i = 0; i<10; i++){
        //     Debug.Log(SectionKanjis[i].kanji);
        // }

        SectionKanjis = param.GetRange(kanji_start_id,kanji_end_id); //出題範囲の漢字に絞り込む
        //Debug.Log(kanji_start_id);
        //Debug.Log(kanji_end_id);

        Debug.Log(SectionKanjis.Count);
    }


    // Update is called once per frame
    void Update()
    {
        QuestionKanjiUGUI.text = SectionKanjis[kanji_question_now].kanji;

        if (Input.GetKey(KeyCode.Space)){
            //Debug.Log(2323232);

            for (int i = 0; i < 10 ; i ++){
                Debug.Log(SectionKanjis[i].kanji);
                Debug.Log(SectionKanjis[i].choices);
            }
            
        }
    }


    public void testNextQuestion(){ 

        if (kanji_question_now < 19) {
            kanji_question_now += 1;
        }else{
            SceneManager.LoadScene("ClearScene");
        }
        Debug.Log(kanji_question_now);
        
    }


}
