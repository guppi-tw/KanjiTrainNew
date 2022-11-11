using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiChoice_circle : MonoBehaviour
{
    public GameObject circle;
    public Image img;

    string imgName;
    int imgNamelast;

    // Start is called before the first frame update
    void Start()
    {
        //circle.SetActive(true);
         //Debug.Log(imgName+" : "+imgNamelast);
         //circle = transform.Find("circle").gameObject;
         update_img_name();
    }

    public void update_img_name(){
        imgName = img.sprite.name;
        imgNamelast = int.Parse(imgName[imgName.Length-1].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (newGameController.isSaiten_now == true){
            if (imgNamelast == (char)0){
                circle.SetActive(true);
                Debug.Log(imgName +":"+imgNamelast);
            }
        }else{
            circle.SetActive(false);
            update_img_name();
        }
    }
}
