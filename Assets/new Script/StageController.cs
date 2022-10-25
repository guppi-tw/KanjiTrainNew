using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public static int StageType = 3;


    // Start is called before the first frame update
    public GameObject FirstAndSecondParts;

    public GameObject ThirdStageParts;
    public GameObject ThirdUIParts;


    void Start()
    {
        if (StageType ==1 || StageType == 2){
            FirstAndSecondParts.SetActive(true);
        }
        else if (StageType == 3){
            ThirdStageParts.SetActive(true);
            ThirdUIParts.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
