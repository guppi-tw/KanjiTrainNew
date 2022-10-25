using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSaitenButton : MonoBehaviour
{

    public GameObject CheckButtons;

    public void Saiten(){
        var saiten = gameObject;
        saiten.SetActive(false);
        CheckButtons.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
