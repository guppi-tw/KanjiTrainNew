using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newAnswerCardController : MonoBehaviour
{

    [SerializeField]
    newGameController newGameController;


    public void pushChoiceButton(){
        var image = this.gameObject.GetComponent<Image>();
        //Debug.Log(image);
        //クリア判定のために画像のファイル名を取得
        string imgName = image.sprite.name;
        var imgNamelast = int.Parse(imgName[imgName.Length-1].ToString());

        //Debug.Log(imgName[imgName.Length-1]);
        //Debug.Log(imgName[imgName.Length-1].GetType());
        if (imgNamelast == (char)0){
            Debug.Log("正解");
            newGameController.makeNewQuestion();

        }else{
            Debug.Log("不正解");
            //newGameController.
        }

    }
}
