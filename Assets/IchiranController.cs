using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IchiranController : MonoBehaviour
{
    public GameObject KanjiCard;
    public List<string> GottenKanji;// = new List<string>(){"漢","字","保","存","機","能","検","査"};
    List<string> defaultValue;
    public GameObject Content;
    //["漢","字","保","存","機","能","検","査"];

    private TextMeshProUGUI CardTM;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save("myInt", 123);
        //ES3.Save("GottenKanji", GottenKanji);
        GottenKanji = ES3.Load("GottenKanji",defaultValue);

        for (int i = 0; i < GottenKanji.Count; i ++){
            var parent = Content.transform;
            KanjiCard =  Instantiate(KanjiCard, parent);
            //Debug.Log(KanjiCard);
            KanjiCard.SetActive(true);
            CardTM = KanjiCard.GetComponentInChildren<TextMeshProUGUI>();
            CardTM.text = GottenKanji[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Kanji_play_data{
    string kanji;
    int ok_count;
    int fail_count;
}
