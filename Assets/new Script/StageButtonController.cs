using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonSetter : MonoBehaviour
{    

    static public int stageID = 1;
    Text stageText;

    // Start is called before the first frame update
    void Start()
    {
        stageText =  this.GetComponentInChildren<Text>();
    }

    void Update() {
        stageText.text = stageID.ToString();
    }

    
}
