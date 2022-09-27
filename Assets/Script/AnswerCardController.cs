using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AnswerCardController : MonoBehaviour
{

    public TextMeshProUGUI AnswerCardKanji;
    public GameController gamecontoller;

    public AudioClip OK_SOUND;
    public AudioClip FAIL_SOUND;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        AnswerCardKanji = this.GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushChoice(){
        if (AnswerCardKanji.text == GameController.QuestionKanji){            
            Debug.Log("正解");
            audioSource.PlayOneShot(OK_SOUND);
            gamecontoller.NextQuestion();            
        }else{
            Debug.Log("不正解");
            audioSource.PlayOneShot(FAIL_SOUND);
        }
    }
}
