using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneButton : MonoBehaviour
{

    int new_day_id = newGameController.day_id;
    int new_level_id = newGameController.level_id;  

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toNextStage(){
        if (newGameController.level_id == 3){
            //最終結果表示シーンの追加と読み込み？
        }else{
            newGameController.level_id += 1;
            SceneManager.LoadScene("NewIngameScene");
        }
    }
}
