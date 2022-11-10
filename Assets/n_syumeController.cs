using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class n_syumeController : MonoBehaviour
{
    public int n = 2;
    public static int n_shu;
    public Text n_shu_UI;

    void Start(){
        n_shu = n;
        n_shu_UI.text = n_shu.ToString();
    }

    void Update(){
        n_shu_UI.text =  n_shu.ToString();//n_shu.ToString();
        //Debug.Log(111);
    }

    public void hideN_shu(){
        this.gameObject.SetActive(false);

    }

    public void updateUI(){
         n_shu_UI.text = n_shu.ToString();
    }

}
