using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;


public class newAnswerCardController : MonoBehaviour
{
    [SerializeField]
    newGameController newGameController;

     [Header("効果音")]
    public AudioClip OKsound;
    public AudioClip FALSEsound;
    public AudioSource audioSource;


    public GameObject thirdButton;
    public GameObject OK_CIRCLE;

    void start(){
        OK_CIRCLE = transform.Find("circle-9").gameObject;
    }


    public int n_shume = 1;
    //public Text n_shu_UI;

    public void pushChoiceButton(){
        string targetKanji_cash = newGameController.targetKanji;

        newGameController.isSaiten_now = true; //強調機能用のフラグ
        var image = this.gameObject.GetComponent<Image>();
        string imgName = image.sprite.name;
        string[] Namearray = imgName.Split('_');
        string img_kanjiID= (int.Parse(Namearray[0]) - 1).ToString();

        var imgNamefirst = imgName[0].ToString();
        var imgNamelast = int.Parse(imgName[imgName.Length-1].ToString());
        

        //ファイルへの書き込み処理
        string datastr = ES3.Load<string>("KANJI_SCORE");
        KanjisSaveData kanjissavedata = JsonUtility.FromJson<KanjisSaveData>(datastr);

        if (newGameController.level_id == 2){
            newGameController.KanjiTargetImage.sprite = Resources.Load<Sprite>("1025版/" + newGameController.mondai_n_str.ToString() + "_" + newGameController.targetKanji + "_0");
        }    

        if (imgNamelast == (char)0){
            //Debug.Log("正解");
            newGameController.number_of_ok += 1;
            audioSource.PlayOneShot(OKsound);
            kanjissavedata.item[newGameController.j].n_OK += 1 * (int)Mathf.Pow(1000,(newGameController.level_id -1));

            if (newGameController.number_of_ok >= 6){
                Debug.Log("ステージクリア");
                StartCoroutine(waitOneSecond());
                SceneManager.LoadScene("NewClearSCene");
            }else{
                StartCoroutine(waitOneSecond());
                newGameController.makeNewQuestion();
            }
            
        }else{
            //Debug.Log("不正解");
            audioSource.PlayOneShot(FALSEsound);   
            kanjissavedata.item[newGameController.j].n_FAIL += 1 * (int)Mathf.Pow(1000,(newGameController.level_id - 1));
            Namearray = imgName.Split('_');
            img_kanjiID = Namearray[0];
            newGameController.syutsudaiToday.Add(newGameController.j.ToString());//不正解なら不正解リストに値を追加(リストの最後に間違った漢字が追加される)

            if (newGameController.level_id != 3){
                StartCoroutine(waitNewQuestion());
            }else{
                newGameController.makeNewQuestion();
            }

        }

        //Debug.Log(newGameController.LastKanji + targetKanji_cash);

        if (newGameController.LastKanji == targetKanji_cash && newGameController.level_id == 3){
            n_syumeController.n_shu += 1;
            Debug.Log(n_syumeController.n_shu);

            newGameController.N_shume_obj.SetActive(true);
            newGameController.LastKanji = newGameController.kanji_Question_Data.param[int.Parse(newGameController.syutsudaiToday[newGameController.syutsudaiToday.Count - 1])].kanji;
        }


        try{
            thirdButton.SetActive(false);
        }catch{
            
        }

        string tes = null;
        for (int i = 0; i< newGameController.syutsudaiToday.Count; i++){
            tes += newGameController.syutsudaiToday[i] + " ";
        }
        //string filePath = Application.dataPath + @"/Resources/Json/text.json";
        string json = JsonUtility.ToJson(kanjissavedata, true);
        ES3.Save<string>("KANJI_SCORE", json);

    }
    

    private IEnumerator waitNewQuestion(){
        newGameController.shield.SetActive(true);
        yield return new WaitForSeconds(5);
        newGameController.makeNewQuestion();
    }

    private IEnumerator waitOneSecond(){
        
        yield return new WaitForSeconds(2);
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
