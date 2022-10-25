using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newAnswerCardController : MonoBehaviour
{

    [SerializeField]
    newGameController newGameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushChoiceButton(){
        var image = this.gameObject.GetComponent<Image>();
        //Debug.Log(image);
        Debug.Log(image.sprite.name);
    }
}
