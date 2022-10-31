using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataCheckButton : MonoBehaviour
{
    public GameObject ScoreDisplayWindow;


    public void showWindow(){

        if (ScoreDisplayWindow.activeSelf == false){
            ScoreDisplayWindow.SetActive(true);
        }else{
            ScoreDisplayWindow.SetActive(true);
        }
        
    }

}
