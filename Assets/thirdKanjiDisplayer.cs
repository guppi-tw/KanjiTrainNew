using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdKanjiDisplayer : MonoBehaviour
{
    public GameObject TargetImage;
    public GameObject thirdButtons;

    public void saitenThird(){
        TargetImage.SetActive(true);
        thirdButtons.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
