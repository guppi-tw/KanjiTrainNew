using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newButtonController : MonoBehaviour
{
    void shokika()
    {
        newGameController.level_id = 1;
        newGameController.number_of_ok = 0;
        newGameController.question_number_now = 0;
    }

    public void toNewMain()
    {
        shokika();
        SceneManager.LoadScene("NewMainScene");
    }
    public void toNewSettings()
    {
        shokika();
        SceneManager.LoadScene("NewSettingScene");
    }
    public void toNewStageSelect()
    {
        shokika();
        
        string[] input_kanji_list;
        var input_kanji_string_d = "0,9,10,11,20,21,26,31,34,36,38,42,47,51,52,55,56,58";
        input_kanji_list = input_kanji_string_d.Split(',');
        ES3.Save<string>("questionText", input_kanji_string_d);
        ES3.Save<string[]>("question_hairetsu", input_kanji_list);
        Debug.Log("問題リストが初期化"+ input_kanji_string_d);


        if (System.IO.File.Exists(Application.persistentDataPath + "/Json/text.json")){
            Debug.Log("漢字データが設定されていません。");
        }else{
            SceneManager.LoadScene("NewStageSelect");
        }
        
    }

    public static int selected_day_id = 1;
    public void toDay1()
    {
        selected_day_id = 1;
        SceneManager.LoadScene("NewIngameScene");
    }
    public void toDay2()
    {
        selected_day_id = 2;
        SceneManager.LoadScene("NewIngameScene");

    }
    public void toDay3()
    {
        selected_day_id = 3;
        SceneManager.LoadScene("NewIngameScene");

    }


    public Text input_UI;
    string res;
    public kanji_question_data kanji_Question_Data;
    public Text questionText;


    public void setQuestionText()
    {
        GameObject inputField = GameObject.Find("InputField");
        InputField input = inputField.GetComponent<InputField>();

        //Debug.Log(input.text);
        var input_kanji_list = input.text.Split(',');
        Debug.Log(input_kanji_list);

        ES3.Save<string>("questionText", input.text);
        ES3.Save<string[]>("question_hairetsu", input_kanji_list);
        Debug.Log(input_kanji_list.Length);


        if (input_kanji_list.Length == 1)
        {
            Debug.Log("空欄のため、初期値がセットされました");
            //var input_kanji_string_d = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29";
            var input_kanji_string_d = "0,9,10,11,20,21,26,31,34,36,38,42,47,51,52,55,56,58";

            input_kanji_list = input_kanji_string_d.Split(',');
            ES3.Save<string>("questionText", input.text);
            ES3.Save<string[]>("question_hairetsu", input_kanji_list);

            //string[] default_kanji_list = new <string>{"0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30"};

        }
        else if (input_kanji_list.Length != 18)
        {
            Debug.Log("要素が18個ではありません");
        }
        else
        {
            Debug.Log("18個の要素が入力されました。");
            Debug.Log(ES3.Load<string>("questionText"));

            string[] id_list = ES3.Load<string[]>("question_hairetsu");
            res = id_list.Length.ToString() + " \n";
            for (int i = 0; i < id_list.Length; i++)
            {
                if (i % 6 == 0 && i != 0)
                {
                    res += "\n";
                }

                res += kanji_Question_Data.param[int.Parse(id_list[i])].kanji + " ";
                
                Debug.Log(int.Parse(id_list[i]));
                Debug.Log(id_list[i] + " : "+ kanji_Question_Data.param[int.Parse(id_list[i])].kanji);
            }
            questionText.text = res;
        }

        //input_UI.text = string.Join(" ",ES3.Load<string[]>("question_hairetsu"));
        //Debug.Log(input_UI.text = string.Join(" ",ES3.Load<string[]>("question_hairetsu")));
    }



}
