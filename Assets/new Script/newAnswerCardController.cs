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

        string imgName = image.sprite.name;
        string[] Namearray = imgName.Split('_');
        Debug.Log(Namearray);
        string img_kanjiID= (int.Parse(Namearray[0]) - 1).ToString();

        var imgNamefirst = imgName[0].ToString();
        var imgNamelast = int.Parse(imgName[imgName.Length-1].ToString());
        
        //Debug.Log(newGameController.number_of_ok);

        if (imgNamelast == (char)0){
            //Debug.Log("正解");
            newGameController.number_of_ok += 1;
            audioSource.PlayOneShot(OKsound);

            if (newGameController.number_of_ok >= 10){
                Debug.Log("ステージクリア");
                SceneManager.LoadScene("NewClearSCene");
            }else{
                newGameController.makeNewQuestion();
            }
        }else{
            //Debug.Log("不正解");
            audioSource.PlayOneShot(FALSEsound);   

            Namearray = imgName.Split('_');
            img_kanjiID = Namearray[0];
            Debug.Log(img_kanjiID);

            newGameController.syutsudaiToday.Add(newGameController.j.ToString());//不正解なら不正解リストに値を追加(リストの最後に間違った漢字が追加される)
            newGameController.makeNewQuestion(); 
        }

        string tes = null;
        for (int i = 0; i< newGameController.syutsudaiToday.Count; i++){
            tes += newGameController.syutsudaiToday[i] + " ";
        }
        Debug.Log(tes);

        //ファイルへの書き込み処理
        

    }
}
