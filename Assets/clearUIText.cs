using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearUIText : MonoBehaviour
{
    public Text displayUI;

    // Start is called before the first frame update
    void Start()
    {
        if ( newGameController.level_id == 1){
            displayUI.text = "次は、ステージ2です。\n 一部分を隠されたお手本と同じ漢字を選んでください。";
        }else if ( newGameController.level_id == 2){
           displayUI.text = "最後に、ステージ３です。\n 例文を読んで、漢字を手元のプリントに書いてください。"; 
        }else{
            displayUI.text = ""; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //displayUI.text = newGameController.level_id.ToString();
    }
}
