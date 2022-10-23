using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class newGameController : MonoBehaviour
{

    public static int section_id;
    public static int question_number_now = 1;
    public kanji_question_data kanji_Question_Data;

    public GameObject KanjiChoiceImages;
    public string imgName = "威_0.jpg";
    public string KanjiTargetName = "威";

    public Text setsumonNumberUI;


    public Image KanjiTargetImage;
    //public GameObject KanjichoicesBox;
    //public GameObject[] KanjiChoicesParents;
    public List<Image> KanjiChoices = new List<Image>(); 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(kanji_Question_Data.param[0].id);
        Debug.Log(kanji_Question_Data.param[0].kanji);
        Debug.Log(kanji_Question_Data.param[0].example);
        makeNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        KanjiTargetName = kanji_Question_Data.param[0].kanji;        
    }

    public void makeNewQuestion(){
        var targetKanji = kanji_Question_Data.param[section_id].kanji;
        Debug.Log(targetKanji);

        KanjiTargetImage.sprite = Resources.Load<Sprite>("DP漢字画像/"+ targetKanji + "_0");

        for (int i = 0; i <4; i++){
            var filename = targetKanji+ "_"+ i.ToString();
            //Debug.Log(filename);
            KanjiChoices[i].sprite = Resources.Load<Sprite>("DP漢字画像/"+ targetKanji + "_" + i.ToString());
        }
        section_id += 1;
    }

}
