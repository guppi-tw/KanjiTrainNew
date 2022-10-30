using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{

    [SerializeField] Text questionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        questionText.text = string.Join(" ",ES3.Load<string[]>("question_hairetsu"));
        //questionText.text = "aaaaaaa";
    }
}
