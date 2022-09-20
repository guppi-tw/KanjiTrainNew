using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void toSyugyou(){
        SceneManager.LoadScene("(Syugyou)StageSelectScene");
    }

    public void toMain(){
        SceneManager.LoadScene("MainScene");
    }

    public void toBouken(){
        SceneManager.LoadScene("BoukenScene");
    }

    public void toGottenKanji(){
        SceneManager.LoadScene("GottenKanjiScene");
    }
}
