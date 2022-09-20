using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerCardController : MonoBehaviour
{

    public TextMeshProUGUI AnswerCardKanji;

    // Start is called before the first frame update
    void Start()
    {
        AnswerCardKanji = this.GetComponentInChildren<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
