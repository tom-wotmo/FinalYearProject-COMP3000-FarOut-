using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUiManager : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the main menu UI
    //
    //
    //
    //
    public void ExitGame()
    {
        Application.Quit();
    }
    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    } 
    public void Credits()
    {

    }
}
