using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newButtonController : MonoBehaviour
{



    public void toNewMain(){
        SceneManager.LoadScene("NewMainScene");
    }

    public void toNewSettings(){
        SceneManager.LoadScene("NewSettingScene");
    }

    public void toNewStageSelect(){
        SceneManager.LoadScene("NewStageSelect");
    }

    public void setQuestionText(){
        GameObject inputField = GameObject.Find("InputField");
        InputField input = inputField.GetComponent<InputField>();
        

        Debug.Log(input.text);
        var input_kanji_list = input.text.Split(',') ;
        Debug.Log(input_kanji_list);
        ES3.Save<string>("questionText", input.text);
        ES3.Save<string[]>("question_hairetsu", input_kanji_list);

        if (input_kanji_list.Length != 30){
            Debug.Log("要素が30個ではありません");
        }else{
            Debug.Log("30個の要素が入力されました。");
            Debug.Log( ES3.Load<string>("questionText"));
            for (int i = 0; i<30; i ++ ){
            //Debug.Log(ES3.Load<string[]>("question_hairetsu")[i]);
        }

        }


    }



}
