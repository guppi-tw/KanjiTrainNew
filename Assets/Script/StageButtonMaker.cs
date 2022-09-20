using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static StageButtonSetter;

public class StageButtonMaker : MonoBehaviour
{
    public GameObject stage_button;


    GameObject btn; //生成時に一時的に受け取る用のもの
    StageButtonController stbSetter;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10 ; i++){
            btn = Instantiate(stage_button, this.transform);
            btn.SetActive(true);
            stbSetter = btn.GetComponent<StageButtonController>();

            stbSetter.stageID = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
