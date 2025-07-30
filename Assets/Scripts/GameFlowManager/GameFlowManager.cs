using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public Button ReStartbutton;
    public Button Lobybutton;


    private void Update()
    {
        
    }

    void ReStartSceneLoadButton()
    {
        SceneManager.LoadScene("MainScene");
    }

}
