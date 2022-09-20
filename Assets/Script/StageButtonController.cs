using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButtonController : MonoBehaviour
{    

    public int stageID = 1;
    Text stageText;

    static public int CHOSEN_STAGE_ID = 0;

    // Start is called before the first frame update
    void Start()
    {
        stageText =  this.GetComponentInChildren<Text>();
        
    }

    void Update(){
        stageText.text = stageID.ToString();

    }

    public void selectToInGame(){
        CHOSEN_STAGE_ID = stageID;
        SceneManager.LoadScene("InGameScene");
    }

    
}
