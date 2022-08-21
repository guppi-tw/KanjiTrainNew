using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public string AnswerKanji = "漢";
    public string ChosenKanji = "漢";


    public Kanji_Data Kanji_Data;
    public List<Kanji_Data.Param> param = new List<Kanji_Data.Param> ();
    

    public List<Kanji_Data.Param> SectionKanjis = new List<Kanji_Data.Param> ();
    //1~200, 201~400, 401~585, 586~766 でそれぞれ3,4,5,6年の漢字が相当。
    //基本的にセクションは20ごとに区切られる

    // Start is called before the first frame update
    void Start()
    {
        param = Kanji_Data.param;
        var SectionKanjis = param.GetRange(0,19); //出題範囲の漢字を選択
        
        for (int i = 0; i<10; i++){
            Debug.Log(SectionKanjis[i].kanji);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            NewQuestion();
            //Debug.Log(2323232);
        }
    }


    public void NewQuestion(){
        Debug.Log("次の問題を呼び出します");

    }


}
