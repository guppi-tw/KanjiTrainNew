using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newAnswerCardController : MonoBehaviour
{

    [SerializeField]
    newGameController newGameController;

     [Header("効果音")]
    public AudioClip OKsound;
    public AudioClip FALSEsound;

    public AudioSource audioSource;

    public void pushChoiceButton(){
        var image = this.gameObject.GetComponent<Image>();
        //Debug.Log(image);
        //クリア判定のために画像のファイル名を取得
        string imgName = image.sprite.name;
        var imgNamefirst = imgName[0].ToString();
        var imgNamelast = int.Parse(imgName[imgName.Length-1].ToString());
        
        if (imgNamelast == (char)0){
            Debug.Log("正解");
        
            newGameController.number_of_ok += 1;
            audioSource.PlayOneShot(OKsound);

            if (newGameController.number_of_ok >= 10){
                Debug.Log("ステージクリア");
                SceneManager.LoadScene("NewClearSCene");
            }else{
                newGameController.makeNewQuestion();
            }
        }else{
            Debug.Log("不正解");
            
            audioSource.PlayOneShot(FALSEsound);
            newGameController.syutsudaiToday.Add(imgNamefirst);//不正解なら不正解リストに値を追加(リストの最後に間違った漢字が追加される)
            newGameController.makeNewQuestion(); 
        }

        //ファイルへの書き込み処理
        



    }
}
