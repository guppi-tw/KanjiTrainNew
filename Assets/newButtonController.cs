using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newButtonController : MonoBehaviour
{

    GameObject inputField;
    InputField input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        ES3.Save<string>("questionText", input.text);
        Debug.Log( ES3.Load<string>("questionText"));
    }



}
