using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newButtonController : MonoBehaviour
{
    void shokika(){
       newGameController.level_id = 1;
       newGameController.number_of_ok = 0;
       newGameController.question_number_now = 0;
    }

    public void toNewMain(){
        shokika();
        SceneManager.LoadScene("NewMainScene");
    }
    public void toNewSettings(){
        shokika();
        SceneManager.LoadScene("NewSettingScene");
    }
    public void toNewStageSelect(){
        shokika();
        SceneManager.LoadScene("NewStageSelect");
    }

    public static int selected_day_id = 1;
    public void toDay1(){
        selected_day_id = 1;
        SceneManager.LoadScene("NewIngameScene");
    }
    public void toDay2(){
        selected_day_id = 2;
        SceneManager.LoadScene("NewIngameScene");
        
    }
    public void toDay3(){
        selected_day_id = 3;
        SceneManager.LoadScene("NewIngameScene");
        
    }


    public Text input_UI;
    public void setQuestionText(){
        GameObject inputField = GameObject.Find("InputField");
        InputField input = inputField.GetComponent<InputField>();
        
        //Debug.Log(input.text);
        var input_kanji_list = input.text.Split(',') ;
        Debug.Log(input_kanji_list);

        ES3.Save<string>("questionText", input.text);
        ES3.Save<string[]>("question_hairetsu", input_kanji_list);
        Debug.Log(input_kanji_list.Length);

        if(input_kanji_list.Length == 1){
            Debug.Log("空欄のため、初期値がセットされました");
            var input_kanji_string_d = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29";
            input_kanji_list = input_kanji_string_d.Split(',') ;
            ES3.Save<string>("questionText", input.text);
            ES3.Save<string[]>("question_hairetsu", input_kanji_list);
            //string[] default_kanji_list = new <string>{"0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30"};
        }else if (input_kanji_list.Length != 30 ){
            Debug.Log("要素が30個ではありません");
        }
        else{
            Debug.Log("30個の要素が入力されました。");
            Debug.Log( ES3.Load<string>("questionText"));
            for (int i = 0; i<30; i ++ ){
            //Debug.Log(ES3.Load<string[]>("question_hairetsu")[i]);
        }
        }

        input_UI.text = string.Join(" ",ES3.Load<string[]>("question_hairetsu"));
        //Debug.Log(input_UI.text = string.Join(" ",ES3.Load<string[]>("question_hairetsu")));
    }



}
