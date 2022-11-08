using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdKanjiDisplayer : MonoBehaviour
{
    public GameObject TargetImage;
    public GameObject thirdButtons;

     [Header("効果音")]
    public AudioClip Displaysound;
    public AudioSource audioSource;

    public void saitenThird(){
        audioSource.PlayOneShot(Displaysound);
        TargetImage.SetActive(true);
        thirdButtons.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
