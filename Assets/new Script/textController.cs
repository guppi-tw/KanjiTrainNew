using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{

    [SerializeField] Text questionText;

    public kanji_question_data kanji_Question_Data;

    string res = "";

    // Start is called before the first frame update
    void Start()
    {
        string[] id_list = ES3.Load<string[]>("question_hairetsu");
        
        res =  id_list.Length.ToString() + " \n";
        for (int i = 0; i < id_list.Length ; i ++){
            res += kanji_Question_Data.param[int.Parse(id_list[i])].kanji + " ";
            if (i % 10 == 0){
                res += "\n";
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        questionText.text = res;
        //questionText.text = "aaaaaaa";
    }
}
