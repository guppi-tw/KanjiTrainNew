using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGameController : MonoBehaviour
{

    public static int section_id;
    public static int question_id;
    public kanji_question_data kanji_Question_Data;

    public GameObject KanjiChoiceImages;
    public 


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(kanji_Question_Data.param[0].id);
        Debug.Log(kanji_Question_Data.param[0].kanji);
        Debug.Log(kanji_Question_Data.param[0].example);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void makeNewQuestion(){
        

    }
}
