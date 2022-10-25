using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFirstSibiling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().SetAsFirstSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
