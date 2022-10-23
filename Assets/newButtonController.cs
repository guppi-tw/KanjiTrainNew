using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toNewMain(){
        SceneManager.LoadScene("NewMainScene");
    }

    public void toNewSettings(){
        SceneManager.LoadScene("NewSettingScene");
    }

    public void toNewStageSelect(){
        SceneManager.LoadScene("NewStageSelect");
    }
}
