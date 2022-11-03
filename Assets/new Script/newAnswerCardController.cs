using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

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

        //ファイルへの書き込み処理
        //StreamReader reader = new StreamReader(Application.dataPath + @"/Resources/Json/text.json");
        string datastr = ES3.Load<string>("KANJI_SCORE");
        //reader.Close();
        //var KANJI_SCORES = JsonUtility.FromJson<KanjiSaveData[]>(datastr);
        KanjisSaveData kanjissavedata = JsonUtility.FromJson<KanjisSaveData>(datastr);
        //読み込み    

        if (imgNamelast == (char)0){
            //Debug.Log("正解");
            newGameController.number_of_ok += 1;
            audioSource.PlayOneShot(OKsound);

            kanjissavedata.item[newGameController.j].n_OK += 1 * (int)Mathf.Pow(1000,(newGameController.level_id -1));

            if (newGameController.number_of_ok >= 10){
                Debug.Log("ステージクリア");
                SceneManager.LoadScene("NewClearSCene");
            }else{
                newGameController.makeNewQuestion();
            }
            
        }else{
            //Debug.Log("不正解");
            audioSource.PlayOneShot(FALSEsound);   
            kanjissavedata.item[newGameController.j].n_OK += 1 * (int)Mathf.Pow(1000,(newGameController.level_id - 1));

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

        //
        //string filePath = Application.dataPath + @"/Resources/Json/text.json";
        string json = JsonUtility.ToJson(kanjissavedata, true);
        //Debug.Log("json="+ kanjissavedata);

        ES3.Save<string>("KANJI_SCORE", json);

        // StreamWriter streamWriter = new StreamWriter(filePath);
        // streamWriter.Write(json);
        // streamWriter.Flush();
        // streamWriter.Close();
    }

    public class KanjisSaveData{
        public KanjiSaveData[] item; 
    }

    [System.Serializable]
    public class KanjiSaveData{
        public int k_id;
        public int n_OK = 0;
        public int n_FAIL = 0;
    }
}
